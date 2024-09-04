using UnityEngine;

public class ObserverTestObj : MonoBehaviour, IObserver
{
    public float PlayerHealth = 0;
    public void OnNotify(EventTypes eventType, object arg)
    {
        if(eventType == EventTypes.PlayerDamaged)
        {
            PlayerHealth = (float)arg;
        }
    }
}
