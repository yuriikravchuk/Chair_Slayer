using enemy;
using player;

namespace gameState
{
    public class BraveState : GameState
    {
        private readonly Map _map;
        private readonly Player _player;
        private readonly EnemySpawner _enemySpawner;
        private readonly RoomsUnlocker _roomsUnlocker;


        public BraveState(Map map, Player player, EnemySpawner enemySpawner)
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

