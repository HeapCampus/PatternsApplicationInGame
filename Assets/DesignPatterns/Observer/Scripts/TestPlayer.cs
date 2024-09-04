using System.Collections;
using System.Collections.Generic;

public class TestPlayer : Subject
{
    public float Health = 100f;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        NotifyObservers(EventTypes.PlayerDamaged, Health);
    }
}
