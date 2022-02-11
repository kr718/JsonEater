using Serilog;
using Autofac;

namespace JsonEater.StartUp.Logger
{
    public class SerilogConfigurer : IStartable
    {
        public static LoggerConfiguration DefaultConfiguration()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console();
        }

        public LoggerConfiguration? Configuration { set; get; }

        public SerilogConfigurer(LoggerConfiguration loggerConfiguration)
        {
            Configuration = loggerConfiguration is not null ? loggerConfiguration : DefaultConfiguration();
        }

        


        public void Configure()
        {
            Log.Logger = Configuration?.CreateLogger();
        }

        public void Start()
        {
            Configure();
            Log.Logger.Information("Logger ha been configured with this Information: {@Configuration} ", Configuration);
        }
    }
}
