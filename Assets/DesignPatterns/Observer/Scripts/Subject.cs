using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void UnregisterObserver(IObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }

    public void NotifyObservers(EventTypes eventType, object arg)
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnNotify(eventType, arg);
        }
    }
}