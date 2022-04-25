using UnityEngine;
using enemy;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _raySpawn;
    [SerializeField] private Transform _sh_spawn;
    [SerializeField] private MuzzleFlash _muzzleFlash;
    [SerializeField] private int _damage;
    [SerializeField] private int _shootDistance = 1000;
    [SerializeField] private float _reloadTime = 0.5f;

    private float _lastShotTime;
    private RaycastHit _hit;
    private Ray _ray;
    private Transform _shell;

    public void TryShoot()
    {
        if (Time.time > _lastShotTime + _reloadTime)
        {
            _ray = new Ray(_raySpawn.position, _raySpawn.forward);
            if(Physics.Raycast(_ray, out _hit, _shootDistance))
            {
                Enemy target = _hit.collider.GetComponent<Enemy>();
                if (target != null)
                {
                    Shoot(target);
                    _lastShotTime = Time.time;
                }
            }

        }
    }

    private void Shoot(Enemy target)
    {
        target.ApplyDamage(_damage);
        _muzzleFlash.Activate();
        SpawnShell();
    }

    private void SpawnShell()
    {
        _shell = PoolManager.Get(22).transform;
        _shell.transform.position = _sh_spawn.transform.position;
        _shell.transform.rotation = _sh_spawn.transform.rotation;
        _shell.gameObject.SetActive(true);
    }
}