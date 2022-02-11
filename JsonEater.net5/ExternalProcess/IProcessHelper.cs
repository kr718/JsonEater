using System.Diagnostics;
using JsonEater.StartUp.Config;

namespace JsonEater.ExternalProcess
{
    public interface IProcessHelper<T>  where T : IConfig
    {
        ProcessStartInfo GetInfo(T config);
    }
}
