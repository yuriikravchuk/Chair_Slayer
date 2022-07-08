﻿using UnityEngine;

public class WallsGenerator : Object
{
    public void Spawn(Room[,] rooms)
    {
        int _maxX = rooms.GetLength(0);
        int _maxY = rooms.GetLength(1);
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                Room forwardRoom = rooms[x, y];
                if (IsLeftBound(x) == false)
                {
                    Wall wall = SpawnWall(forwardRoom.transform, 0);
                    forwardRoom.walls[0] = wall;
                    Room backwardRoom = rooms[x - 1, y];
                    backwardRoom.walls[2] = wall;
                    wall.Init(forwardRoom, backwardRoom);
                }

                if(IsTopBound(y) == false)
                {
                    Wall wall = SpawnWall(forwardRoom.transform, 1);
                    forwardRoom.walls[1] = wall;
                    Room backwardRoom = rooms[x, y - 1];
                    backwardRoom.walls[3] = wall;
                    wall.Init(forwardRoom, backwardRoom);
                }
            }
        }
    }

    private Wall SpawnWall(Transform currentRoom, int wallIndex)
        => Instantiate(MapConfig.Wall, currentRoom.transform.position, Quaternion.Euler(0, 90 * (wallIndex + 1), 0), currentRoom)       ;


    private bool IsLeftBound(int x) => x == 0;
    private bool IsTopBound(int y) => y == 0;
}
