using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColleagueRed : BaseColleagueModule
{
    public float BlueHealth = 100f;

    public override void OnMessageReceived(params object[] args)
    {
        if (args.Length > 1)
        {
            switch ((string)args[0])
            {
                case "OnBlueDamage":
                    BlueHealth = (float)args[1];
                    break;
                default:
                    break;
            }
        }
    }
}
