using Autofac;
using JsonEater.StartUp.Logger;
using JsonEater.StartUp.Config;

namespace JsonEater.DI
{
    public class StartUpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(provicer => SerilogConfigurer.DefaultConfiguration()).As<Serilog.LoggerConfiguration>();
            builder.RegisterType<SerilogConfigurer>().AsSelf().As<IStartable>();
            builder.RegisterType<ConfigurationReader>().AsImplementedInterfaces();
            builder.Register(provider => provider.Resolve<ConfigurationReader>().GetConfig()).As<PandaGeneratorConfig>();
        }
    }
}
