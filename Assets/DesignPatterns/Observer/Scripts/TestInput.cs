using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public TestPlayer player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.TakeDamage(1);
        }
    }
}
