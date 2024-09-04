using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 2f;
    public Action<Bullet> OnDestroy;
    private float damage;
    private float range;

    private Vector3 direction;
    private bool go = false;
    private float deltaMove;

    private void OnEnable()
    {
        deltaMove = 0f;
    }

    private void Update()
    {
        if(go)
        {
            Vector3 translation = direction * speed *Time.deltaTime;
            transform.LookAt(transform.position + direction);
            transform.Translate(translation, Space.World);
            deltaMove += translation.magnitude;

            if (deltaMove > range)
            {
                // Out of range
                OnDestroy?.Invoke(this);
                deltaMove = 0;
            }
        }
    }

    public void Go(Vector3 direction, float damage, float range, float speed)
    {
        go = true;
        this.direction = direction;
        this.damage = damage;
        this.range = range;
        this.speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Hit(damage);
                OnDestroy?.Invoke(this);
            }
        }
    }
}
