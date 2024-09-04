using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObserverAutoRegisterer : MonoBehaviour
{
    private void Start()
    {
        IObserver[] observers = FindObjectsOfType<MonoBehaviour>().OfType<IObserver>().ToArray();

        Subject[] subjects = FindObjectsOfType<Subject>();

        foreach (var subject in subjects)
        {
            foreach (var observer in observers)
            {
                subject.RegisterObserver(observer);
            }
        }
    }
}
