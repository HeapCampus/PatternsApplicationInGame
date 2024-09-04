using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator Animator;
    public float Speed = 1f;
    public float Health = 100f;
    public Action<Enemy> OnDied;
    public ParameterConfig Config;
    public Renderer Renderer;
    public Material DefaultMat;
    public Material OnTargetMat;

    private Transform target;

    private void OnEnable()
    {
        if(Config != null)
            Speed = Config.EnemySpeed;

        Health = 100f;
        ResetMaterial();
    }

    public void SetTarget(Transform tr)
    {
        target = tr;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction = direction.normalized;

            transform.Translate(direction * Speed * Time.deltaTime, Space.World);
            transform.LookAt(target.position);
        }
    }

    public void Hit(float damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
            //Enemy is dead
            Health = 0;
            OnDied?.Invoke(this);
        }
    }

    public void ChangeToTargetMat()
    {
        Renderer.material = OnTargetMat;
    }

    public void ResetMaterial()
    {
        Renderer.material = DefaultMat;
    }

}
