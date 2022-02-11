namespace JsonEater.StartUp.Config
{
    public class PandaGeneratorConfig : IConfig
    {
        public string ProcessPath { get; set; }

        public PandaGeneratorConfig(string processPath)
        {
            ProcessPath = processPath;
        }
    }
}