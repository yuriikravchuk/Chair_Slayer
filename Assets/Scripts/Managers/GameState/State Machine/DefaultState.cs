using enemy;

namespace gameState
{
    public class DefaultState : GameState
    {
        private readonly Map _map;
        private readonly EnemySpawner _enemySpawner;

        public DefaultState(Map map, EnemySpawner enemySpawner)
        {
            _map = map;
            _enemySpawner = enemySpawner;
        }

        public override void Enter()
        {
            _map.HideWallTriggers();
            _enemySpawner.SpawnActive = true;
        }
    }
}

