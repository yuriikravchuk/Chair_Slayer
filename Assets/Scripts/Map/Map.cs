using UnityEngine;

public class Map
{
    public Room[,] Rooms { get;}
    public Room BossRoom { get; }
    public Room StartRoom { get; }
    public Vector3 StartPosition => StartRoom.transform.position;

    private readonly int _boundX;
    private readonly int _boundY;
    public Map(Room[,] rooms, Vector2Int startRoomIndex, Vector2Int bossRoomIndex)
    {
        Rooms = rooms;
        _boundX = Rooms.GetLength(0);
        _boundY = Rooms.GetLength(1);
        BossRoom = Rooms[bossRoomIndex.x, bossRoomIndex.y];
        StartRoom = Rooms[startRoomIndex.x, startRoomIndex.y];
        StartRoom.Activate();
    }

    public void ShowWallTriggers() => ChangeTriggersActive(true);

    public void HideWallTriggers() => ChangeTriggersActive(false);

    private void ChangeTriggersActive(bool active)
    {
        for (int x = 0; x < _boundX; x++)
        {
            for (int y = 0; y < _boundY; y++)
            {
                if(Rooms[x, y]?.Active == true)
                    Rooms[x, y].ChangeTriggersActive(active);
            }                 
        }
    }
}
