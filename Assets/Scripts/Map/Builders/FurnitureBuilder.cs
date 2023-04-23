using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureBuilder
{
    public void Build(Room[,] rooms, Vector2Int startRoomIndex, Vector2Int bossRoomIndex)
    {
        int boundX = rooms.GetLength(0);
        int boundY = rooms.GetLength(1);
        Room startRoom = rooms[startRoomIndex.x, startRoomIndex.y];
        Room bossRoom = rooms[bossRoomIndex.x, bossRoomIndex.y];
        GameObject startRoomFurniture = GameObject.Instantiate(MapConfig.StartRoomFurniture, startRoom.transform.position, Quaternion.identity, startRoom.transform);
        GameObject bossRoomFurniture = GameObject.Instantiate(MapConfig.BossRoomFurniture, startRoom.transform.position, Quaternion.identity, startRoom.transform);
        startRoom.AddStaticObject(startRoomFurniture);
        bossRoom.AddStaticObject(bossRoomFurniture);
        for (int x = 0; x < boundX; x++)
        {
            for (int y = 0; y < boundY; y++)
            {
                if (rooms[x, y].Avaible == false)
                    continue;

                if (x == startRoomIndex.x && y == startRoomIndex.y)
                    continue;

                if (x == bossRoomIndex.x && y == bossRoomIndex.y)
                    continue;

                //Quaternion rotation = Quaternion.
                //PlaceRandomFurniture(rooms[x, y].transform.position, rotation);
            }
        }
    }
    
    private void PlaceRandomFurniture(Vector3 position, Quaternion rotation)
    {

    }
}
