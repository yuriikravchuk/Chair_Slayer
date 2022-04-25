using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(WallBreaker))]
public class MapGeneratorsFacade : UnityEngine.Object
{
    private Room _spawnRoom;

    private WallBreaker _wallBreaker;

    private WallsGenerator _wallsGenerator;

    private const int _maxX = 3, _maxY = 3;
    private Vector2Int _spawnIndex = new Vector2Int(2, 2);

    private const float _roomLengh = 12.5f;
    private const float _roomHeight = 2.51f;
    private const int _floorsCount = 5;

    public MapGeneratorsFacade(Room spawnRoom)
    {
        _spawnRoom = spawnRoom;

    }

    public Map Generate()
    {
        Room[,] rooms = GetRooms();
        Map map = new Map(rooms);

        SpawnWindows(rooms);
        SpawnWalls(rooms);
        SpawnFloors();

        _wallBreaker = new WallBreaker();
        _spawnRoom.Activate();

        return map;
    }
    public void WreckWall(Wall wall) =>
    _wallBreaker.WreckWall(wall);

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
        RoomsGenerator roomsGenerator = new RoomsGenerator(_maxX, _maxY, _spawnRoom, _spawnIndex);
        return roomsGenerator.GetRooms();
    }

}