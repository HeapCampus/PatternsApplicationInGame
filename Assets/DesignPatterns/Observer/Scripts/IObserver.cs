public interface IObserver
{
    void OnNotify(EventTypes eventType, object arg);
}
