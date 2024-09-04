using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColleagueBlue : BaseColleagueModule
{
    public float Health = 100f;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Notify(typeof(ColleagueRed), "OnBlueDamage", Health);
    }

    public override void OnMessageReceived(params object[] args)
    {

    }
}
