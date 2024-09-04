using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float Speed = 1f;
    public Transform FollowTarget;
    public Transform LookTarget;
    public Vector3 Offset;
    private Transform CameraTr;

    private void Start()
    {
        CameraTr = Camera.main.transform;
    }

    private void LateUpdate()
    {
        CameraTr.position = Vector3.Lerp(CameraTr.position, FollowTarget.position + Offset, Time.deltaTime * Speed);

        if (LookTarget != null)
        {
            CameraTr.LookAt(LookTarget.position);
        }
    }
}
