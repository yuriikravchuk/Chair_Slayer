using UnityEngine;
using enemy;
using System;

public class EnemiesManager : IClosestTargetFinder, IEnemiesHandler
{
    public event Action EnemyDie;

    public KdTree<Enemy> _enemies = new KdTree<Enemy>();

    public Vector3 GetClosestTargetPosition(Vector3 playerPosition)
    {
        if (_enemies.Count > 0)
            return _enemies.FindClosest(playerPosition);
        else
            return playerPosition;
    }
    public void AddToList(Enemy current)
        => _enemies.Add(current);

    public void RemoveFromList(Enemy current)
    {
        //BoostSpawner.instance.TrySpawn(current.transform.position);
        _enemies.Remove(current);
        //_enemies.RemoveAt(_enemies.ToList().IndexOf(current));

        EnemyDie?.Invoke();
    }

    public void ReturnAllEnemies() => PoolManager.ReturnAllEnemies();
}

public interface IClosestTargetFinder
{
    Vector3 GetClosestTargetPosition(Vector3 position);
}

public interface IEnemiesHandler
{
    void AddToList(Enemy enemy);
    void RemoveFromList(Enemy enemy);
}
