using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterSet", menuName = "ScriptableObjects/Parameters", order = 1)]

public class ParameterConfig : ScriptableObject
{
    public float PlayerSpeed;
    public float EnemySpeed;
    public float BulletSpeed;
    public float BulletPeriod;
}
