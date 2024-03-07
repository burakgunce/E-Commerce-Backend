
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistence;
using ETicaretAPI.Infrastructure;
using FluentValidation.AspNetCore;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using ETicaretAPI.Infrastructure.Services.Storage.Azure;
using ETicaretAPI.Application;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Serilog.Core;
using NpgsqlTypes;
using Serilog.Sinks.PostgreSQL;
using System.Security.Claims;

namespace ETicaretAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddPersistenceServices();// IoC Container
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

            //builder.Services.AddStorage(StorageType.Azure);
            //builder.Services.AddStorage<LocalStorage>();
            builder.Services.AddStorage<AzureStorage>();

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
            ));

            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true,
                columnOptions: new Dictionary<string, ColumnWriterBase>
                {
                    {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
                    {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
                    {"level", new LevelColumnWriter(true , NpgsqlDbType.Varchar)},
                    {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
                    {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
                    {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
                    //{"user_name", new UsernameColumnWriter()}
                })
                .CreateLogger();
            
            builder.Host.UseSerilog();
            
            builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

                        NameClaimType = ClaimTypes.Name // to get name value from User.Identity.Name on jwt
                    };
                });

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}