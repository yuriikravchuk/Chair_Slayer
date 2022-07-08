﻿public class BraveStateMediator 
{
    private int _killCount;
    private readonly int _killsToBraveState = 20;
    private readonly GameStateSwitcher _gameStateSwitcher;
    public BraveStateMediator(GameStateSwitcher gameStateSwitcher, EnemiesManager enemiesManager)
    {
        enemiesManager.EnemyDie += IncreaseKillCount;
        _gameStateSwitcher = gameStateSwitcher;
    }

    public void IncreaseKillCount()
    {
        _killCount++;
        if (_killCount >= _killsToBraveState)
            _gameStateSwitcher.SetBraveState();
            
    }
}