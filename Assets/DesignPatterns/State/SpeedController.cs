using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float Speed = 0f;
    public float MaxSpeed = 4f;
    public float deltaSpeedUp = 0.01f;
    public float deltaSpeedDown = 0.01f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            SpeedUp();
        }
        else
        {
            SpeedDown();
        }
    }

    private void SpeedUp()
    {
        Speed += deltaSpeedUp;

        if(Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    private void SpeedDown()
    {
        Speed -= deltaSpeedDown;
        if (Speed < 0)
        {
            Speed = 0f;
        }
    }
}
