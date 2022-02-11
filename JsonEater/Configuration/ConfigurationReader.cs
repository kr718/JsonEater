namespace JsonEater
{
    public class ConfigurationReader
    {
        public static void GetProcessPath( out pandaGeneratorConfig config, string innerConfigLocation)
        {
            using (var f = new StreamReader(Directory.GetCurrentDirectory() + innerConfigLocation))
            {
                var fileContent = f.ReadToEnd();
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<pandaGeneratorConfig>(fileContent);
            }

        }
    }
    public class pandaGeneratorConfig
    {
        public string ProcessPath { get; protected set; }
        
        [Newtonsoft.Json.JsonConstructor]
        public pandaGeneratorConfig(string processPath)
        {
            ProcessPath = processPath;
        }
    }
}
