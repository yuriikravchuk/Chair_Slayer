using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomsGenerator : Object
{
    private readonly Vector2Int _spawnIndex;
    private const float _roomLengh = 12.5f;
    private readonly Room _spawnRoom;
    private readonly int _maxX, _maxY;
    private readonly int _avaibleRooms;
    private Room[,] _rooms;
    public RoomsGenerator(int maxX, int maxY,Room spawnRoom, Vector2Int spawnIndex)
    {
        _maxX = maxX;
        _maxY = maxY;
        _spawnRoom = spawnRoom;
        _spawnIndex = spawnIndex;
        _avaibleRooms = (_maxX * _maxY + 1) / 2;
    }

    public Room[,] GetRooms()
    {
        _rooms = InstantiateRooms();
        _rooms[_spawnIndex.x, _spawnIndex.y] = _spawnRoom;
        _spawnRoom.SetAvailbe();

        for (int i = 0; i < _avaibleRooms; i++)
        {
            Vector2Int roomIndex = GetIndexOfAvaibleRoom();
            _rooms[roomIndex.x, roomIndex.y].SetAvailbe();
            //InstantiateRoom(roomIndex.x, roomIndex.y);
        }

        return _rooms;
    }

    private Vector2Int GetIndexOfAvaibleRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();

        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                if (!_rooms[x, y].Avaible)
                    continue;

                if (x > 0)
                    vacantPlaces.Add(new Vector2Int(x - 1, y));

                if (y > 0)
                    vacantPlaces.Add(new Vector2Int(x, y - 1));

                if (x < _maxX - 1)
                    vacantPlaces.Add(new Vector2Int(x + 1, y));

                if (y < _maxY - 1)
                    vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }
        Vector2Int roomIndex = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
        return roomIndex;
    }

    private Room[,] InstantiateRooms()
    {
        Room[,] _rooms = new Room[_maxX, _maxY];
        _rooms[_spawnIndex.x, _spawnIndex.y] = _spawnRoom;
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                if (x == _spawnIndex.x && y == _spawnIndex.y)
                    continue;

                _rooms[x, y] = InstantiateRoom(x, y);
            }
        }

        return _rooms;
    }

    private Room InstantiateRoom(int x, int y) =>
    Instantiate(MapConfig.Room, new Vector3(x - _spawnIndex.x, 0, -(y - _spawnIndex.y)) * _roomLengh, Quaternion.identity).GetComponent<Room>();
}