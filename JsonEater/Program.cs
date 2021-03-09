//https://github.com/bigpandaio/challenge/tree/backend-engineer

using System.Threading;
using Serilog;

namespace JsonEater
{
    
    class Program
    {

        static void Main(string[] args)
        {
            //Startup Configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console().CreateLogger();

            //autofac DI
            //building the generatorProcess
            var config = ConfigurationReader.GetProcessPath(innerConfigLocation: "\\Configuration\\config.json");
            var info = PandaGenerator.CreateGeneratorProcessInfo(config.ProcessPath);
            var process = PandaGenerator.CreateGeneratorProcess(info);
            

            //building the manager
            IConsumeEvents<PandaEvent> consumer = new PandaConsumer<PandaEvent>(process);
            IConsumptionWorker worker = new ConsumptionWorker<PandaEvent>(consumer);
            IConsumptionManager manager = new ConsumptionManager<PandaEvent>(worker, new CancellationTokenSource());

            manager.Start();

        }
    }
}
