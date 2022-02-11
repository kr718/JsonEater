using System.Text.Json;

namespace JsonEater
{
    public class PandaEvent 
    {
        public string EventType { get;  }
        public string Data { get; }
        public DateTime Timestamp { get; }


        public PandaEvent(string event_type, string data, int timestamp )
        {
            EventType = event_type;
            Data = data;
            Timestamp = new DateTime(timestamp);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
