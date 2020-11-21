using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace JsonEater
{
    public class ConfigurationReader
    {
        public static pandaGeneratorConfig GetProcessPath(string innerConfigLocation = "\\Configuration\\config.json")
        {
            using (var f = new StreamReader(Directory.GetCurrentDirectory() + innerConfigLocation))
            {
                var fileContent = f.ReadToEnd();
                var pgc = Newtonsoft.Json.JsonConvert.DeserializeObject<pandaGeneratorConfig>(fileContent);
                return pgc;
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
