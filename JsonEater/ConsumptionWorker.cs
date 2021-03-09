using System.Threading;
using Serilog;
namespace JsonEater
{
    public class ConsumptionWorker<T> : IConsumptionWorker
    {
        private IConsumeEvents<T> _consumer;

        public ConsumptionWorker(IConsumeEvents<T> consumeEvents)
        {
            _consumer = consumeEvents;
        }
        public void Start(CancellationToken token)
        {
            while (_consumer.IsUp && !token.IsCancellationRequested)
            {
                try
                {
                    var d = _consumer.consumeEvent();
                    Log.Logger.Information(d.ToString());
                }
                catch 
                {
                    Log.Logger.Error("there was an Error parsing the message");
                }
                
            }
        }


    }
}

