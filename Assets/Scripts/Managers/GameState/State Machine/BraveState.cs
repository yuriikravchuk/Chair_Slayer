namespace gameState
{
    public class BraveState : GameState
    {
        private Map _map;
        private PlayerFacade _player;
        private EnemySpawner _enemySpawner;
        private RoomsUnlocker _roomsUnlocker;


        public BraveState(Map map, PlayerFacade player, EnemySpawner enemySpawner)
        {
            _map = map;
            _player = player;
            _enemySpawner = enemySpawner;
        }
        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {

        }
    }
}

