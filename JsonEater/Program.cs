//https://github.com/bigpandaio/challenge/tree/backend-engineer

using System.Threading;
using System;
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
            pandaGeneratorConfig config;
            ConfigurationReader.GetProcessPath(out config, innerConfigLocation: @"\Configuration\ConfigurationReader.cs");
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
