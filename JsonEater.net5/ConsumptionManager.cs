namespace JsonEater
{

    public class ConsumptionManager<T> : IConsumptionManager
    {
        private CancellationTokenSource _cancellationTokenSource;

        private Thread _thread;
        public ConsumptionManager(IConsumptionWorker worker, CancellationTokenSource cancellationTokenSource)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _thread = new Thread(()=>worker.Start(_cancellationTokenSource.Token));
        }
        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

    }

}
