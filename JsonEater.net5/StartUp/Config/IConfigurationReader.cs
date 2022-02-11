using System.Text.Json;
using JsonEater.StartUp.Config;

namespace JsonEater.StartUp.Config
{
    public interface IConfigurationReader<T>
    {
        T GetConfig(string innerConfigLocation);
        
    }
}