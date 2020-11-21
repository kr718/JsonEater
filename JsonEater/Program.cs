using System;
using System.Collections.Generic;

namespace JsonEater
{
    class Program
    {

        static void Main(string[] args)
        {
            var config = ConfigurationReader.GetProcessPath(innerConfigLocation: "\\Configuration\\config.json");
            var info = PandaGenerator.CreateGeneratorProcessInfo(config.ProcessPath);
            IConsumeEvents<PandaEvent> consumer = new PandaConsumer<PandaEvent>(info); // maybe process should be outside
            var keepGoing = true;
            while (keepGoing)
            {
                try
                {
                    var d = consumer.consumeEvent();
                    Console.WriteLine(d);
                    Console.WriteLine($"IS process running: {consumer.IsUp}");
                }
                catch
                {
                    keepGoing = false;
                }

            }

        }
    }
}
