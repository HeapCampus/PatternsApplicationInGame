using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 Direction = Vector3.zero;
    public static float DeltaAngle = 0;
    private void Update()
    {

        Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            Direction += Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Direction += Vector3.back;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            Direction += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector3.left;
        }

        if(!Input.anyKey)
        {
            Direction = Vector3.zero;
        }

        DeltaAngle = Input.GetAxis("Mouse X");

    }
}
