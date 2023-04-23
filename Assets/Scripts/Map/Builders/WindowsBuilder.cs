using UnityEngine;

namespace map
{
    public class WindowsBuilder : Object
    {
        private readonly int _maxX, _maxY;
        private readonly Room[,] _rooms;
        private const float _top = 180;
        private const float _bottom = 0;
        private const float _left = 90;
        private const float _right = 270;

        public WindowsBuilder(Room[,] rooms)
        {
            _rooms = rooms;
            _maxX = rooms.GetLength(0);
            _maxY = rooms.GetLength(1);
        }

        public void Build(int floorCount, float height)
        {
            float tempHeight = 0;
            for (int i = 0; i < floorCount; i++)
            {
                SpawnInOneFloor(tempHeight);
                tempHeight -= height;
            }
        }

        private void SpawnInOneFloor(float height)
        {
            Vector2Int roomIndex = new Vector2Int(0, 0); // current room
            for (int i = 0; i < _maxX; i++) // spawn horizontal
            {
                // upper edge
                roomIndex.y = 0;
                SpawnWindow(roomIndex, _top, height);
                //lower edge
                roomIndex.y = _maxY - 1;
                SpawnWindow(roomIndex, _bottom, height);

                roomIndex.x++;
            }

            for (int i = 0; i < _maxY; i++) //spawn vertical
            {
                // right edge
                roomIndex.x = _maxX - 1;
                SpawnWindow(roomIndex, _right, height);
                // left edge
                roomIndex.x = 0;
                SpawnWindow(roomIndex, _left, height);

                roomIndex.y--;
            }
        }

        private void SpawnWindow(Vector2Int roomIndex, float rotation, float height)
        {
            Vector3 position = _rooms[roomIndex.x, roomIndex.y].transform.position;
            position.y = height;
            Instantiate(MapConfig.Window, position, Quaternion.Euler(0, rotation, 0));
        }
    }
}