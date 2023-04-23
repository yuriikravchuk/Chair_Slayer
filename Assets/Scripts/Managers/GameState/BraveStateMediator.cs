public class BraveStateMediator 
{
    private int _killCount;
    private readonly int _killsToBraveState = 2;
    private readonly GameStateSwitcher _gameStateSwitcher;
    public BraveStateMediator(GameStateSwitcher gameStateSwitcher, IEnemyDieEventHandler eventHandler)
    {
        eventHandler.EnemyDie += IncreaseKillCount;
        _gameStateSwitcher = gameStateSwitcher;
    }

    public void IncreaseKillCount()
    {
        _killCount++;
        if (_killCount >= _killsToBraveState)
            _gameStateSwitcher.SetBraveState();  
    }
}
