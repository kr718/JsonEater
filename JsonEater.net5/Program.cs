//https://github.com/bigpandaio/challenge/tree/backend-engineer

using Autofac;
using Serilog;
using JsonEater.DI;
using JsonEater.ExternalProcess;

namespace JsonEater
{

    class Program
    {

        static void Main(string[] args)
        {
            var assembly = typeof(StartUpModule).Assembly;
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(assembly);

            using (var containerLifeScope = builder.Build())
            {
                
            }

            //building the manager
            IConsumeEvents<PandaEvent> consumer = new PandaConsumer<PandaEvent>(process);
            IConsumptionWorker worker = new ConsumptionWorker<PandaEvent>(consumer);
            IConsumptionManager manager = new ConsumptionManager<PandaEvent>(worker, new CancellationTokenSource());

            manager.Start();

        }
    }
}
