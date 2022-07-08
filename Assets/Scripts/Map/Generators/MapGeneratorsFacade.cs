using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(BreakingWall))]
public class MapGeneratorsFacade : UnityEngine.Object
{
    private WallsGenerator _wallsGenerator;

    private const int _maxX = 3, _maxY = 3;
    private Vector2Int _spawnIndex = new Vector2Int(2, 2);

    private const float _roomLengh = 12.5f;
    private const float _roomHeight = 2.51f;
    private const int _floorsCount = 5;

    public Map Generate()
    {
        Room[,] rooms = GetRooms();
        Map map = new Map(rooms);

        SpawnWindows(rooms);
        SpawnWalls(rooms);
        SpawnFloors();

        rooms[_spawnIndex.x, _spawnIndex.y].Activate();
        return map;
    }

    private void SpawnFloors()
    {
        Vector3 floorPosition = new Vector3(-_spawnIndex.x, 0, _spawnIndex.y) * _roomLengh - new Vector3(_roomLengh / 2, 0, -_roomLengh / 2);
        FloorsGenerator floorsGenerator = new FloorsGenerator(_maxX, _maxY, _roomHeight);
        floorsGenerator.Spawn(floorPosition, 3);
    }

    private void SpawnWalls(Room[,] rooms)
    {
        _wallsGenerator = new WallsGenerator();
        _wallsGenerator.Spawn(rooms);
    }

    private void SpawnWindows(Room[,] rooms)
    {
        WindowsGenerator windowsGenerator = new WindowsGenerator(rooms);
        windowsGenerator.Spawn(_floorsCount, _roomHeight);
    }

    private Room[,] GetRooms()
    {
        RoomsGenerator roomsGenerator = new RoomsGenerator(_maxX, _maxY, _spawnIndex);
        return roomsGenerator.GetRooms();
    }

}