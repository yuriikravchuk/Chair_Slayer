public class BossStateMediator
{
    private readonly GameStateSwitcher _stateSwitcher;
    private int _unlockedRoomsCount = 1;
    private readonly int _roomsToBossFight = 2;
    public BossStateMediator(GameStateSwitcher stateSwitcher, WallWrecker wrecker)
    {
        _stateSwitcher = stateSwitcher;
        wrecker.Wrecked += OnRoomUnlocked;
    }

    private void OnRoomUnlocked()
    {
        _unlockedRoomsCount++;

        if (_unlockedRoomsCount >= _roomsToBossFight)
            _stateSwitcher.SetBossFightState();
    }
}
