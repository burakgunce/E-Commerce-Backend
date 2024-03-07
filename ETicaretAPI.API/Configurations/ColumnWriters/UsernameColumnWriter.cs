using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ETicaretAPI.API.Configurations.ColumnWriters
{
    public class UsernameColumnWriter : ColumnWriterBase
    {
        public UsernameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            throw new NotImplementedException();
        }
    }
}
