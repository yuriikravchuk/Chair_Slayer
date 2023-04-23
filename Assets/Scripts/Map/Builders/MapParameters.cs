using UnityEngine;

namespace map
{
    class MapParameters
    {
        public Vector2Int StartRoomIndex { get; private set; }
        public Vector2Int BossRoomIndex { get; private set; }
        public Vector2Int Bounds { get; private set; }

        private enum Side { Left, Top, Right, Bottom };
        private const int _sidesCount = 4;

        public MapParameters(int minSize, int maxSize)
        {
            int boundX = Random.Range(minSize, maxSize);
            int boundY = Random.Range(minSize, maxSize);
            Bounds = new Vector2Int(boundX, boundY);
            int startSideIndex = Random.Range(0, _sidesCount - 1);
            int bossSideIndex = GetOppositeSideIndex(startSideIndex);
            StartRoomIndex = GetRandomIndexInSide((Side)startSideIndex);
            BossRoomIndex = GetRandomIndexInSide((Side)bossSideIndex);
        }


        private Vector2Int GetRandomIndexInSide(Side side)
        {
            switch (side)
            {
                case Side.Left:
                    return new Vector2Int(0, Random.Range(0, Bounds.y - 1));
                case Side.Top:
                    return new Vector2Int(Random.Range(0, Bounds.x - 1), 0);
                case Side.Right:
                    return new Vector2Int(Bounds.x - 1, Random.Range(0, Bounds.y - 1));
                case Side.Bottom:
                    return new Vector2Int(Random.Range(0, Bounds.x - 1), Bounds.y - 1);
            }
            throw new System.InvalidOperationException();
        }

        private int GetOppositeSideIndex(int sideIndex)
        {
            int halfOfSides = _sidesCount / 2;
            return sideIndex >= halfOfSides ? sideIndex - halfOfSides : sideIndex + halfOfSides;
        }
    }
}
