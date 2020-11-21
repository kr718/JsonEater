using System;
using Newtonsoft.Json;

namespace JsonEater
{
    public class PandaEvent 
    {
        public string EventType { get;  }
        public string Data { get; }
        public DateTime Timestamp { get; }

        [JsonConstructor]

        public PandaEvent(string event_type, string data, int timestamp )
        {
            EventType = event_type;
            Data = data;
            Timestamp = new DateTime(timestamp);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
