using UnityEngine;

public class DefaultStateMediator
{
    private readonly GameStateSwitcher _gameStateSwitcher;
    public DefaultStateMediator(GameStateSwitcher gameStateSwitcher, WallWrecker wallWrecker)
    {
        _gameStateSwitcher = gameStateSwitcher;
        wallWrecker.EndWrecking += SetDefaultState;
    }

    private void SetDefaultState()
    {
        Debug.Log("End");
        _gameStateSwitcher.SetDefaultState();
    }

}
