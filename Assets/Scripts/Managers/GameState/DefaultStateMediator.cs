using UnityEngine;

public class DefaultStateMediator
{
    private readonly GameStateSwitcher _gameStateSwitcher;
    public DefaultStateMediator(GameStateSwitcher gameStateSwitcher, WallWrecker wallWrecker)
    {
        _gameStateSwitcher = gameStateSwitcher;
        wallWrecker.EndWrecking += SetDefaultState;
    }

    private void SetDefaultState() => _gameStateSwitcher.SetDefaultState();

}
