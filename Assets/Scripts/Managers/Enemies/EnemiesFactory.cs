using System;

namespace enemy
{
    public class EnemiesFactory
    {
        public event Action<Enemy> Spawned;
        public event Action<Enemy> Died;

        private readonly IBossProvider _bossProvider;
        private readonly ISimpleEnemyProvider _enemyProvider;

        public EnemiesFactory(ISimpleEnemyProvider enemyProvider, IBossProvider bossProvider)
        {
            _enemyProvider = enemyProvider;
            _bossProvider = bossProvider;
        }

        public SimpleEnemy GetSimpleEnemy(int enemyType)
        {
            var enemy = _enemyProvider.GetSimpleEnemy(enemyType);
            Spawned.Invoke(enemy);
            return enemy;
        }

        public Boss GetBoss(int level)
        {
            var boss = _bossProvider.GetBoss(level);
            Spawned.Invoke(boss);
            return boss;
        }

        public void Return(Enemy enemy)
        {
            Died.Invoke(enemy);
        }
    }

    public interface IBossProvider
    {
        Boss GetBoss(int level);
    }

    public interface ISimpleEnemyProvider
    {
        SimpleEnemy GetSimpleEnemy(int enemyType);
    }
}

