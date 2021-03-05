using System.Threading;
namespace JsonEater
{
    public interface IConsumptionWorker
    {
        void Start(CancellationToken token);
    }
}