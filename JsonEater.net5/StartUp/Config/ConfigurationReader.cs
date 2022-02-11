using System.Text.Json;

namespace JsonEater.StartUp.Config
{
    public class ConfigurationReader : IConfigurationReader<PandaGeneratorConfig>
    {
        public PandaGeneratorConfig GetConfig(string innerConfigLocation = "/config.json")
        {
            var config = JsonSerializer.Deserialize<PandaGeneratorConfig>(File.ReadAllText(Directory.GetCurrentDirectory() + innerConfigLocation));
            if (config is null)
            {
                throw new Exception("config read came as Null reference");
            }

            return config;
        }

    }
}

