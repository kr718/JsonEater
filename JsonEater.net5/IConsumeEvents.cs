namespace JsonEater
{
    public interface IConsumeEvents<T>
    {
        T consumeEvent();
        bool IsUp { get; }
    }
}
