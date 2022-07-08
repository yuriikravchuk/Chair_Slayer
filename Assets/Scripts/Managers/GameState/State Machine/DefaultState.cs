namespace gameState
{
    public class DefaultState : GameState
    {
        private Map _map;
        //private PlayerFacade _player;
        private EnemySpawner _enemySpawner;
        public DefaultState(Map map, EnemySpawner enemySpawner)
        {
            _map = map;
            //_player = player;
            _enemySpawner = enemySpawner;
        }
        public override void Enter()
        {
            _map.HideWallTriggers();
            //_player.SetDefaultState();
            _enemySpawner.SpawnActive = true;
        }
    }
}

