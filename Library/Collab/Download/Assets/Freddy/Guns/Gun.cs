using UnityEngine;
using UnityNightPool;
using enemy;
using System.Runtime.InteropServices.ComTypes;
//using System.Numerics;

public class Gun : MonoBehaviour
{
    public Transform spawn;
    public float semiSpeed;
    public float autoSpeed;
    float currentspeed;
    float lastShotTime;
    public float damage;

    Vector3 movement;
    Vector3 direction;
    Quaternion rot;

    public MuzzleFlash muzzleFlash;
    RaycastHit hit;
    float shootDistance = 1000;
    Ray ray;
    //public LayerMask mask;

    public Transform shell;
    public Transform sh_spawn;
    public Enemy nearestObj = null;
    //Transform target;

    public enum GunType { Semi, Auto };
    public GunType guntype;

    void OnEnable()
    {
        lastShotTime = 0;
        if (guntype == GunType.Auto)
        {
            currentspeed = autoSpeed;
            damage = 20;
        }
        else
        {
            currentspeed = semiSpeed;
            damage = 50;
        }
    }


    public void Fire()
    {
        Aim();
        if (Time.time > lastShotTime + currentspeed)
            Shoot();
    }

    public Enemy FindColsestEnemy()
    {
        nearestObj = EnemiesController.Instance.FindClosestEnemy(spawn);
        return nearestObj;
    }

    void Shoot()
    {
        ray = new Ray(spawn.position, spawn.forward);
        if (Physics.Raycast(ray, out hit, shootDistance))
        {
            if (hit.collider.tag == "Enemy")
            {
                lastShotTime = Time.time;
                shell = PoolManager.Get(2).transform;
                shell.transform.position = sh_spawn.transform.position;
                shell.transform.rotation = sh_spawn.transform.rotation;
                shell.gameObject.SetActive(true);
                muzzleFlash.Activate();
                nearestObj = hit.collider.GetComponent<Enemy>();
                nearestObj.Health -= damage;
            }
        }
    }

    void Aim()
    {
        movement = new Vector3(nearestObj.center.position.x - spawn.position.x, 0, nearestObj.center.position.z - spawn.position.z);
        direction = Vector3.RotateTowards(transform.forward, movement, 1, 0);
        rot = Quaternion.LookRotation(direction);
        transform.rotation = rot;
    }
}

