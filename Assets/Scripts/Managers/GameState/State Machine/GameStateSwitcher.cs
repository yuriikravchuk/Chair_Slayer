using UnityEngine;
using enemy;
using player;

public class GameStateSwitcher
{
    private readonly Map _map;
    private readonly EnemySpawner _enemySpawner;
    private readonly PlayerStateMachine _player;

    public GameStateSwitcher(Map map, EnemySpawner enemySpawner, PlayerStateMachine player)
    {
        _map = map;
        _enemySpawner = enemySpawner;
        _player = player;
    }

    public void SetBraveState()
    {
        _enemySpawner.SpawnActive = false;
        _map.ShowWallTriggers();
        _player.GetRootState<BraveState>();
    }

    public void SetDefaultState()
    {
        _map.HideWallTriggers();
        _enemySpawner.SpawnActive = true;
        _player.GetRootState<DefaultState>();
    }

    public void SetBossFightState(Vector3 spawnPosition)
    {

    }

    public void SetPauseState()
    {

    }
}
