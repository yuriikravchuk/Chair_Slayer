using System;

public class Map
{
    public Room[,] Rooms { get;}
    private readonly int _maxX;
    private readonly int _maxY;
    public Map(Room[,] rooms)
    {
        Rooms = rooms;
        _maxX = Rooms.GetLength(0);
        _maxY = Rooms.GetLength(1);
    }

    //public void DisableEnemySpawn() => ChangeEnemySpawnActive(false);
    //public void EnableEnemySpawn() => ChangeEnemySpawnActive(true);

    public void ShowWallTriggers() => ChangeTriggersActive(true);

    public void HideWallTriggers() => ChangeTriggersActive(false);

    private void ChangeTriggersActive(bool active)
    {
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
                    Rooms[x, y]?.ChangeTriggersActive(active);
        }
    }

    private void SetDefaultState()
    {
        ChangeTriggersActive(false);
        //ChangeEnemySpawnActive(true);
    }

    private void SetBraveState()
    {

    }
}
