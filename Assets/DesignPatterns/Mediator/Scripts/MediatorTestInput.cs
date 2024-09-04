using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorTestInput : MonoBehaviour
{
    public ColleagueBlue blue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blue.TakeDamage(1);
        }
    }
}