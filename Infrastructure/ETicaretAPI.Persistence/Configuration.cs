using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                //ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                //configurationManager.AddJsonFile("appsettings.json");

                //return configurationManager.GetConnectionString("PostgreSQL");

                string jsonFilePath = "C:\\Users\\PC\\Desktop\\ETicaretProjesi\\ETicaretAPI\\ETicaretAPI.API\\appsettings.json"; // 

                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile(jsonFilePath, optional: false, reloadOnChange: true);

                IConfigurationRoot configuration = configurationBuilder.Build();

                return configuration.GetConnectionString("PostgreSQL");


            }
        }
    }
}
