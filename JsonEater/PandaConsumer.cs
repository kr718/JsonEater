using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Serilog;
namespace JsonEater
{
    public class PandaConsumer<T> : IConsumeEvents<T>
    {
        private readonly Process _process;

        public bool IsUp { get { return !_process.HasExited; } }
        public PandaConsumer(ProcessStartInfo info)
        {
            _process = new Process();
            _process.StartInfo = info;
            _process.Start();
        }

        public T consumeEvent()
        {
            var eventString = _process.StandardOutput.ReadLine();
            try
            {
                var jsonDictionary = JsonConvert.DeserializeObject<T>(eventString);
                return jsonDictionary;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return default(T);
            }

        }

    }
}
