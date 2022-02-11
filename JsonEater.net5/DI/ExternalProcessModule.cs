using System.Diagnostics;
using Autofac;
using JsonEater.ExternalProcess;
using JsonEater.StartUp.Config;

namespace JsonEater.DI
{
    public class ExternalProcessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(builder => 
                    builder.Resolve<IProcessHelper<PandaGeneratorConfig>>().GetInfo(builder.Resolve<PandaGeneratorConfig>())
                ).As<ProcessStartInfo>();

            builder.RegisterType<PandaGeneratorProcessManager>().AsImplementedInterfaces();
        }
    }
}
