public class GameStateSwitcher
{
    private readonly Map _map;
    private readonly EnemySpawner _enemySpawner;
    private readonly PlayerFacade _player;

    public GameStateSwitcher(Map map, EnemySpawner enemySpawner, PlayerFacade player)
    {
        _map = map;
        _enemySpawner = enemySpawner;
        _player = player;
    }

    public void SetBraveState()
    {
        _enemySpawner.SpawnActive = false;
        _map.ShowWallTriggers();
        _player.SetBraveState();
    }

    public void SetDefaultState()
    {
        _map.HideWallTriggers();
        _enemySpawner.SpawnActive = true;
        _player.SetDefaultState();
    }

    public void SetBossFightState()
    {

    }

    public void SetPauseState()
    {

    }
}
