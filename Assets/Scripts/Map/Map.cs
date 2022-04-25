using System;

public class Map
{
    public Room[,] Rooms { get;}
    private readonly int _maxX;
    private readonly int _maxY;
    private RoomsUnlocker _roomsUnlocker;
    public Map(Room[,] rooms, RoomsUnlocker roomsUnlocker)
    {
        Rooms = rooms;
        _maxX = Rooms.GetLength(0);
        _maxY = Rooms.GetLength(1);
        _roomsUnlocker = roomsUnlocker;
    }

    //public void DisableEnemySpawn() => ChangeEnemySpawnActive(false);
    //public void EnableEnemySpawn() => ChangeEnemySpawnActive(true);

    //public void ShowWallTriggers() => ChangeTriggersActive(true);

    //public void HideWallTriggers() => ChangeTriggersActive(false);

    private void ChangeEnemySpawnActive(bool active) // SpawnController
    {
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                if (Rooms[x, y]?.Active == true)
                    Rooms[x, y].ChangeSpawnActive(active);
            }
        }
    }

    private void ChangeTriggersActive(bool active)
    {
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
                    Rooms[x, y]?.ChangeTriggersActive(active);
        }
    }

    public void ActivateNextRoom(Wall brakedWall)
    {
        _roomsUnlocker.ActivateNextRoom(brakedWall);
        SetDefaultState();
    }

    private void SetDefaultState()
    {
        ChangeTriggersActive(false);
        ChangeEnemySpawnActive(true);
    }

    private void SetBraveState()
    {

    }
}
