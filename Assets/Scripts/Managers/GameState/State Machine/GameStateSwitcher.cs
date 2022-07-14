using playerStateMachine;
using UnityEngine;

public class GameStateSwitcher
{
    private readonly Map _map;
    private readonly EnemySpawner _enemySpawner;
    private readonly PlayerStateMachine _player;
    //private readonly MenuManager _menu;

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
        _player.SetRootState<BraveState>();
    }

    public void SetDefaultState()
    {
        _map.HideWallTriggers();
        _enemySpawner.SpawnActive = true;
        _player.SetRootState<DefaultState>();
    }

    public void SetBossFightState()
    {
        //_enemySpawner.S
    }

    public void SetPause() 
        => Time.timeScale = 0f;

    public void Resume() 
        => Time.timeScale = 1f;
}
