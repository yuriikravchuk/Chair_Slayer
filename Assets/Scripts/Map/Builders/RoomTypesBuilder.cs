//using System;
using UnityEngine;

namespace map
{
    public class RoomTypesBuilder
    {
        public Room StartRoom => _rooms[_startRoomIndex.x, _startRoomIndex.y];
        public Room BossRoom { get; private set; }

        private Vector2Int _startRoomIndex;


        private readonly Room[,] _rooms;
        private readonly int _maxX, _maxY;

        public RoomTypesBuilder(Room[,] rooms, Vector2Int startRoomIndex)
        {
            _rooms = rooms;
            _maxX = _rooms.GetLength(0);
            _maxY = _rooms.GetLength(1);
            _startRoomIndex = startRoomIndex;
        }

        public void Generate()
        {
            for (int x = 0; x < _maxX; x++)
            {
                for (int y = 0; y < _maxY; y++)
                {
                    if (_rooms[x, y].Avaible)
                    {

                    }
                }
            }
        }



        private void SetBossRoom()
        {

        }
    }
}