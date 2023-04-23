using UnityEngine;
using enemy;
using System;

namespace enemy
{
    public class EnemiesContainer : IClosestTargetFinder, IEnemiesContainer, IEnemyDieEventHandler
    {
        public event Action EnemyDie;

        public KdTree<Enemy> _list = new KdTree<Enemy>();

        public Vector3 GetClosestPosition(Vector3 playerPosition)
            => _list.GetClosestPosition(playerPosition);
        public void Add(Enemy current)
            => _list.Add(current);

        public void Remove(Enemy current)
        {
            _list.Remove(current);

            EnemyDie?.Invoke();
        }
    }
}
public interface IClosestTargetFinder
{
    Vector3 GetClosestPosition(Vector3 position);
}

public interface IEnemyDieEventHandler
{
    event Action EnemyDie;
}

public interface IEnemiesContainer
{
    void Add(Enemy enemy);
    void Remove(Enemy enemy);
}