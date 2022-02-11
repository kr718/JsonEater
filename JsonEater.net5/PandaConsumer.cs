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
        public PandaConsumer(Process process)
        {
            _process = process;
        }

        /// <summary>
        /// consume a event from the process and returns it or throws exception. 
        /// </summary>
        /// <returns>Type T or Exception if corrupted</returns>
        public T consumeEvent()
        {
            var jsonString = _process.StandardOutput.ReadLineAsync();
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<T>(jsonString.Result);
                return jsonObject;
            }
            catch (Exception e)
            {
                Log.Logger.Debug(e.Message);
                throw e;
            }

        }

    }
}

