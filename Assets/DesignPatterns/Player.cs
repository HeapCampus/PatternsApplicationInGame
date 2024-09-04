using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Shooter Shooter;
    public float Health = 100f;
    public float Speed = 1f;
    public float RotationSpeed = 30f;
    public Animator Animator;

    public Transform ClosestEnemyTr;

    private void Update()
    {
        Vector3 translation = InputManager.Direction * Speed * Time.deltaTime;
        transform.Translate(translation, Space.World);
        if(GameManager.Mode == GameMode.Normal)
            transform.eulerAngles = transform.eulerAngles + Vector3.up * InputManager.DeltaAngle * RotationSpeed * Time.deltaTime;
        else if(GameManager.Mode == GameMode.Ulti)
        {
            RotateToPosition();
        }

        float magnitude = InputManager.Direction.magnitude;
        Debug.Log($"magnitude : {magnitude}");

        if (magnitude > 0 )
        {
            Animator.SetFloat("walk", 1f);
        }
        else
        {
            Animator.SetFloat("walk", 0f);
            Animator.SetTrigger("idle");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Health -= Time.deltaTime * 5f;
        }
    }

    private void RotateToPosition()
    {
        if (ClosestEnemyTr == null)
        {
            return;
        }
        Vector3 processedPos = ClosestEnemyTr.position;
        processedPos.y = transform.position.y;
        Vector3 direction = processedPos - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }


}
