using UnityEngine;

namespace map
{
    public class RoomsBuilder : Object
    {
        private readonly Vector2Int _spawnIndex;
        private const float _roomLengh = 12.5f;
        private readonly int _maxX, _maxY;

        private Room[,] _rooms;

        public RoomsBuilder(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public Room[,] GetRooms()
        {

            _rooms = InstantiateRooms();
            return _rooms;
        }

        private Room[,] InstantiateRooms()
        {
            var rooms = new Room[_maxX, _maxY];
            for (int x = 0; x < _maxX; x++)
            {
                for (int y = 0; y < _maxY; y++)
                    rooms[x, y] = InstantiateRoom(x, y);
            }
            return rooms;
        }

        private Room InstantiateRoom(int x, int y)
    => Instantiate(MapConfig.Room, new Vector3(x, 0, -y) * _roomLengh, Quaternion.identity);
    }
}