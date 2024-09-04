using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public ObjectPool BulletPool;

    public Transform BulletSpawnRef;

    public LineRenderer LineRenderer;

    public float BulletSpeed = 2f;

    public float Period = 1f;

    public float Damage = 35f;

    public float Range = 20f;

    public bool IsShootingActive = false;

    private float timer = 0f;

    private Vector3 playerAim;

    private Enemy LastInteractedEnemy;

    private void Update()
    {
        if(IsShootingActive)
        {
            timer += Time.deltaTime;

            if (timer >= Period)
            {
                //Bullet move command
                MoveBullet();
                timer = 0f;
            }
        }

    }

    private void FixedUpdate()
    {

        Vector3 fwd = transform.forward; //transform.TransformDirection(transform.forward);

        Debug.DrawRay(BulletSpawnRef.position , fwd * Range, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(BulletSpawnRef.position, fwd, out hit, Range))
        {
            Debug.Log("There is something in front of the object!");
            IsShootingActive = true;
            LineRenderer.SetPosition(0, BulletSpawnRef.position);
            LineRenderer.SetPosition(1, hit.point);
            playerAim = (hit.point - BulletSpawnRef.position).normalized;

            var enemy = hit.collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.ChangeToTargetMat();
                LastInteractedEnemy = enemy;
            }
        }
        else
        {
            IsShootingActive=false;

            LineRenderer.SetPosition(0, BulletSpawnRef.position);
            LineRenderer.SetPosition(1, transform.position + Vector3.up + fwd * Range);

            if(LastInteractedEnemy != null)
                LastInteractedEnemy.ResetMaterial();
        }

    }

    private void MoveBullet()
    {
        var obj = BulletPool.GetPoolObject();
        obj.transform.position = BulletSpawnRef.position;
        obj.SetActive(true);

        Bullet bullet = obj.GetComponent<Bullet>();

        if(bullet != null )
        {
            bullet.OnDestroy += OnBulletDestroy;
            bullet.Go(playerAim, Damage, Range, BulletSpeed);
        }
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        BulletPool.ReturnPoolObject(bullet.gameObject);
        bullet.OnDestroy -= OnBulletDestroy;
    }
}
