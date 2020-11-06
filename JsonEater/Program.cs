using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JsonEater
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = new ProcessStartInfo();
            info.FileName = @"C:\code\JsonEater\generator-windows-amd64.exe";
            info.UseShellExecute = false;
            info.CreateNoWindow = false;
            info.RedirectStandardOutput = true;

            IConsumeEvents consumer = new PandaConsumer(info);

            while (consumer.IsUp) 
            {
                var d = consumer.consumeEvent();
                if(d == null)
                {
                    Console.WriteLine("Error json");
                }
                else Console.WriteLine(d["event_type"]);
            }
        }
    }

    public interface IConsumeEvents<T>
    {
        T consumeEvent();
        bool IsUp { get; }
    }

    public class PandaConsumer<T> : IConsumeEvents<T>
    {
        private readonly Process _process ;
        private bool _isUp;


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
            catch { return null; }
            
        }

    }
    public class EventsJson 
    {
        public string EventType { get;  }
        public string Data { get; }
        public DateTime Timestamp { get; }

        [JsonConstructor]

        public EventsJson(string event_type, string data, int timestamp )
        {
            EventType = event_type;
            Data = data;
            Timestamp = new DateTime(timestamp);
        }
    }
}
