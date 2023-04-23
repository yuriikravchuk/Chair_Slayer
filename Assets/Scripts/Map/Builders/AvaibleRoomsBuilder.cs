using algorithms;
using UnityEngine;

namespace map
{
    public class AvaibleRoomsBuilder
    {
        private readonly Room[,] _rooms;
        private readonly MatrixPathFinder _pathFinder;
        private readonly Vector2Int _startRoomIndex;
        private readonly Vector2Int _bossRoomIndex;
        private enum Side { Left, Top, Right, Bottom };
        private const int _sidesCount = 4;
        private readonly int _boundX, _boundY;

        private readonly int _avaibleRoomsCount;
        public AvaibleRoomsBuilder(Room[,] rooms, Vector2Int startRoomIndex, Vector2Int bossRoomIndex)
        {
            _rooms = rooms;
            _boundX = _rooms.GetLength(0);
            _boundY = _rooms.GetLength(1);
            _startRoomIndex = startRoomIndex;
            _bossRoomIndex = bossRoomIndex;
            _avaibleRoomsCount = (_boundX * _boundY + 1) / 2;
            _pathFinder = new MatrixPathFinder(_boundX, _boundY);
        }

        public void Build()
        {
            var mainRoomsIndexes = _pathFinder.GetPath(_startRoomIndex, _bossRoomIndex);
            foreach (Vector2Int index in mainRoomsIndexes)
            {
                _rooms[index.x, index.y].SetAvailable();
                //_rooms[index.x, index.y].Activate();
            }
        }

    }
}