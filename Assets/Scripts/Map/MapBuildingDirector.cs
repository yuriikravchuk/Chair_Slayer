using UnityEngine;

namespace map
{
    public class MapBuildingDirector : IMapProvider
    {
        //private const int _maxX = 3, _maxY = 3;
        private const float _roomLengh = 12.5f;
        private const float _roomHeight = 2.51f;
        private const int _floorsCount = 5;
        private const int _minSize = 3;
        private const int _maxSize = 5;
        public Map GetMap()
        {
            var mapParameters = new MapParameters(_minSize, _maxSize);
            Room[,] rooms = GetRooms(mapParameters.Bounds);
            SetAvaiableRooms(rooms, mapParameters.StartRoomIndex, mapParameters.BossRoomIndex);
            BuildWindows(rooms);
            BuildWalls(rooms);
            BuildFloors(mapParameters.Bounds);
            BuildFurniture(rooms, mapParameters.StartRoomIndex, mapParameters.BossRoomIndex);
            return new Map(rooms, mapParameters.StartRoomIndex, mapParameters.BossRoomIndex); ;
        }

        private void SetAvaiableRooms(Room[,] rooms, Vector2Int startRoomIndex, Vector2Int bossRoomIndex)
        {
            var avaibleRoomsBuilder = new AvaibleRoomsBuilder(rooms, startRoomIndex, bossRoomIndex);
            avaibleRoomsBuilder.Build();
        }

        private Room[,] GetRooms(Vector2Int bounds)
        {
            var roomsBuilder = new RoomsBuilder(bounds.x, bounds.y);
            return roomsBuilder.GetRooms();
        }


        private void BuildFloors(Vector2Int bounds)
        {
            Vector3 floorPosition = - new Vector3(_roomLengh / 2, 0, -_roomLengh / 2);
            var floorsBuilder = new FloorsBuilder(bounds.x, bounds.y, _roomHeight);
            floorsBuilder.Build(floorPosition, 3);
        }

        private void BuildWalls(Room[,] rooms)
        {
            var wallsBuilder = new WallsBuilder();
            wallsBuilder.Build(rooms);
        }

        private void BuildWindows(Room[,] rooms)
        {
            var windowsBuild = new WindowsBuilder(rooms);
            windowsBuild.Build(_floorsCount, _roomHeight);
        }

        private void BuildFurniture(Room[,] rooms, Vector2Int startRoomIndex, Vector2Int bossRoomIndex)
        {
            var furnitureBuilder = new FurnitureBuilder();
            furnitureBuilder.Build(rooms, startRoomIndex, bossRoomIndex);
        }
    }
}
