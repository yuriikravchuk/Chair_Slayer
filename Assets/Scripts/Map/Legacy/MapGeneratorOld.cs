using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MapGeneratorOld : ScriptableObject
{
    //[SerializeField] private GameObject wreck_wall;
    //[SerializeField] private GameObject stat_wall;
    //[SerializeField] private WallBreaker _wallBreaker;

    //[SerializeField] private GameObject roomPref;
    //[SerializeField] private GameObject wallPref;
    //[SerializeField] private GameObject windowPref;
    //[SerializeField] private GameObject floorPref;

    //[SerializeField] private Room spawnRoom;



    //public PlayerFacade Player;
    //public Camera MainCam;

    ////private WallSpawner[] static_walls;
    ////private Animator _wreck_anim;
    //private Room[,] _rooms;
    //private int _maxX = 3;
    //private int _maxY = 3;
    //private int _spawnX = 0;
    //private int _spawnY = 0;
    //private int _avaibleRoomsCount = 0;
    //private int _enabledRooms = 0;
    //private const float roomLengh = 12.5f;


    //public void SetBraveState()
    //{
    //    ChangeTriggersActive(true);

    //    Player.SetBraveState();
    //    ChangeEnemySpawnActive(false);
    //}
    //public void WreckWall(Transform wall) // WallBreaker
    //{
    //    _wallBreaker.WreckWall(wall);
    //    //wreck_wall.transform.position = wall.transform.position;
    //    //wreck_wall.transform.rotation = wall.transform.rotation;
    //    //wreck_wall.SetActive(true);
    //    //Instantiate(stat_wall, wreck_wall.transform.position, wreck_wall.transform.rotation);
    //    //ChangeTriggersActive(false);
    //    //_wreck_anim.SetBool("wrecking", true);
    //    //Invoke(nameof(RestoreAfterWrecking), 4);
    //}
    //public void ReloadLevel()
    //{
    //    LevelManager.LoadScene(0);
    //}
    //public void ActivateNextRoom(Room currentRoom, WallSpawner currentWall)
    //{
    //    int indexOfBrakedWall = Array.IndexOf(currentRoom.walls, currentWall);
    //    for (int i = 0; i < _maxX; i++)
    //    {
    //        for (int j = 0; j < _maxY; j++)
    //        {
    //            Room tempRoom = _rooms[i, j];
    //            if (tempRoom && tempRoom.Equals(currentRoom))
    //            {
    //                Room nextRoom = null;
    //                int x = i, y = j;
    //                switch (indexOfBrakedWall)
    //                {
    //                    case 0:
    //                        x -= 1;
    //                        break;
    //                    case 1:
    //                        y -= 1;
    //                        break;
    //                    case 2:
    //                        x += 1;
    //                        break;
    //                    case 3:
    //                        y += 1;
    //                        break;
    //                    default:
    //                        UnityEngine.Debug.LogError("Can't find next room");
    //                        break;
    //                }

    //                int indexOfBrakedWallInNextRoom = -1;
    //                if (indexOfBrakedWall > 2)
    //                    indexOfBrakedWallInNextRoom = indexOfBrakedWall - 2;
    //                else
    //                    indexOfBrakedWallInNextRoom = indexOfBrakedWall + 2;

    //                nextRoom = _rooms[x, y];
    //                if (nextRoom != null)
    //                {
    //                    nextRoom.Activate();
    //                    if (_enabledRooms == 3)
    //                    {
    //                        EnemiesManager.instance.SpawnBoss(nextRoom.transform, 1);
    //                    }
    //                    PlaceWalls(x, y, indexOfBrakedWallInNextRoom);
    //                    _enabledRooms++;
    //                }
    //                else
    //                {
    //                    UnityEngine.Debug.LogError("Room isn't founded");
    //                }
    //                return;

    //            }
    //        }
    //    }
    //}

    //private void Awake()
    //{
    //    SaveManager.deathEvent.AddListener(ReloadLevel);
    //    SaveManager.deathEvent.AddListener(DisableSpawn);
    //}
    //private void Start()
    //{
    //    _avaibleRoomsCount = (_maxX * _maxY + 1) / 2;
    //    SpawnRooms();
    //    PlaceWindows();
    //    PlaceWalls(_spawnX, _spawnY);
    //    SpawnFloors();
    //    spawnRoom.Activate();

    //    //wreck_wall = Instantiate(wreck_wall);
    //    //_wreck_anim = wreck_wall.GetComponentInChildren<Animator>();
    //    //wreck_wall.SetActive(false);
    //}


    //private void InstantiateRoom(int x, int y)
    //{
    //    Room newRoom = Instantiate(roomPref, new Vector3(x - _spawnX, 0, -(y - _spawnY)) * roomLengh, Quaternion.identity, transform).GetComponent<Room>();
    //    _rooms[x, y] = newRoom;
    //}

    //private void SpawnRooms()
    //{
    //    _rooms = new Room[_maxX, _maxY];
    //    _rooms[_spawnX, _spawnY] = spawnRoom;
    //    for (int x = 0; x < _maxX; x++)
    //    {
    //        for (int y = 0; y < _maxY; y++)
    //        {
    //            if (x == _spawnX && y == _spawnY)
    //                continue;

    //            InstantiateRoom(x, y);
    //        }
    //    }
    //}

    //private void RestoreAfterWrecking() // WallBreaker
    //{
    //    wreck_wall.SetActive(false);
    //    _wreck_anim.SetBool("wrecking", false);
    //    ChangeEnemySpawnActive(true);
    //}

    //private void ChangeTriggersActive(bool active)
    //{
    //    for (int x = 0; x < _maxX; x++)
    //    {
    //        for(int y = 0; y < _maxY; y++)
    //            if(_rooms[x, y])
    //                _rooms[x, y].ChangeTriggersActive(active);
    //    }
    //}
    //private void DisableSpawn() =>// SpawnController
    //    ChangeEnemySpawnActive(false);
    //private void ChangeEnemySpawnActive(bool active) // SpawnController
    //{
    //    for(int x = 0; x < _maxX; x++)
    //    {
    //        for(int y = 0; y < _maxY; y++)
    //        {
    //            Room currentRoom = _rooms[x, y];
    //            if (currentRoom && currentRoom.Active)
    //            {
    //                currentRoom.ChangeSpawnActive(active);
    //                //Room currentRoom = _rooms[x, y];
    //                //for (int j = 0; j < 4; j++)
    //                //{
    //                //    if (currentRoom.walls[j])
    //                //        currentRoom.walls[j].SpawnActive = current;
    //                //}
    //            }
    //        }
    //    }
    //}

    //private void PlaceWalls(int x, int y, int indexOfBrakedWall = 5)
    //{
    //    Room currentRoom = _rooms[x, y];
    //    int curX, curY, wallIndexInNextRoom, step = -1;

    //    for (int wallIndex = 0; wallIndex < 4; wallIndex++)
    //    {
    //        curX = x;
    //        curY = y;
    //        wallIndexInNextRoom = -1;

    //        if (wallIndex % 2 == 0)
    //            curX += step;
    //        else
    //            curY += step;


    //        if (step < 0)
    //            wallIndexInNextRoom = wallIndex + 2;
    //        else
    //            wallIndexInNextRoom = wallIndex - 2;

    //        if (wallIndex == 1)
    //            step = -step;

    //        if (wallIndex == indexOfBrakedWall)
    //            continue;

    //        Room nextRoom = null;
    //        if (curX >= 0 && curX < _maxX && curY >= 0 && curY < _maxY)
    //            nextRoom = _rooms[curX, curY];
    //        else
    //            continue;

    //        if (nextRoom && nextRoom.Active)
    //        {
    //            currentRoom.walls[wallIndex] = nextRoom.walls[wallIndexInNextRoom];
    //            nextRoom.walls[wallIndexInNextRoom].HasRoomInBack = true;
    //        }
    //        else
    //        {
    //            currentRoom.walls[wallIndex] = Instantiate(wallPref, currentRoom.transform.position, Quaternion.Euler(0, 90 * (wallIndex + 1), 0), currentRoom.transform).GetComponent<WallSpawner>();
    //            currentRoom.walls[wallIndex].forward = currentRoom;
    //        }
    //    }

    //}
    //private void CreateRooms()
    //{
    //    _rooms = new Room[_maxX, _maxY];
    //    _rooms[_spawnX, _spawnY] = spawnRoom;

    //    for(int i = 0; i < _avaibleRoomsCount; i++)
    //    {
    //        PlaceOneRoom();
    //    }
    //    GameObject floor = Instantiate(floorPref, new Vector3(-0.5f - _spawnX, 0, -(-0.5f - _spawnY)) * roomLengh, Quaternion.identity, transform);
    //    floor.transform.localScale = new Vector3(_maxX, 1, _maxY);

    //    PlaceWindows();
    //    PlaceWalls(_spawnX, _spawnY);
    //    SpawnFloors();
    //    spawnRoom.Activate();

    //    void PlaceOneRoom()
    //    {
    //        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();

    //        for (int x = 0; x < _maxX; x++)
    //        {
    //            for (int y = 0; y < _maxY; y++)
    //            {
    //                if (!_rooms[x, y])
    //                    continue;

    //                if (x > 0 && !_rooms[x - 1, y])
    //                    vacantPlaces.Add(new Vector2Int(x - 1, y));

    //                if (y > 0 && !_rooms[x, y - 1])
    //                    vacantPlaces.Add(new Vector2Int(x, y - 1));

    //                if (x < _maxX - 1 && !_rooms[x + 1, y])
    //                    vacantPlaces.Add(new Vector2Int(x + 1, y));

    //                if (y < _maxY - 1 && !_rooms[x, y + 1])
    //                    vacantPlaces.Add(new Vector2Int(x, y + 1));
    //            }
    //        }
    //        Vector2Int roomIndex = vacantPlaces.ElementAt(UnityEngine.Random.Range(0, vacantPlaces.Count));
    //        InstantiateRoom(roomIndex.x, roomIndex.y);
    //    }
        
    //}
    //private void PlaceWindows()
    //{
    //    Vector2Int roomIndex = new Vector2Int(0, 0); // current room
    //    WallSpawner window;
    //    for (int i = 0; i < _maxX; i++) // spawn horizontal
    //    {
    //        // upper edge
    //        roomIndex.y = 0;
    //        window = Instantiate(windowPref, new Vector3(roomIndex.x - _spawnX, 0, -roomIndex.y + _spawnY) *
    //            roomLengh, Quaternion.Euler(0, 180, 0), transform).GetComponent<WallSpawner>();
    //        if (_rooms[roomIndex.x, roomIndex.y])
    //            _rooms[roomIndex.x, roomIndex.y].walls[1] = window;
    //        //lower edge
    //        roomIndex.y = _maxY - 1;

    //        window = Instantiate(windowPref, new Vector3(roomIndex.x - _spawnX, 0, -roomIndex.y + _spawnY) *
    //            roomLengh, Quaternion.Euler(0, 0, 0), transform).GetComponent<WallSpawner>();
    //        if (_rooms[roomIndex.x, roomIndex.y])
    //            _rooms[roomIndex.x, roomIndex.y].walls[3] = window;
    //        roomIndex.x++;
    //    }

    //    for (int i = 0; i < _maxY; i++) //spawn vertical
    //    {
    //        // right edge
    //        roomIndex.x = _maxX - 1;
    //        window = Instantiate(windowPref, new Vector3(roomIndex.x - _spawnX, 0, -roomIndex.y + _spawnY) *
    //            roomLengh, Quaternion.Euler(0, 270, 0), transform).GetComponent<WallSpawner>();
    //        if (_rooms[roomIndex.x, roomIndex.y])
    //            _rooms[roomIndex.x, roomIndex.y].walls[0] = window;

    //        // left edge
    //        roomIndex.x = 0;
    //        window = Instantiate(windowPref, new Vector3(roomIndex.x - _spawnX, 0, -roomIndex.y + _spawnY) *
    //            roomLengh, Quaternion.Euler(0, 90, 0), transform).GetComponent<WallSpawner>();
    //        if (_rooms[roomIndex.x, roomIndex.y])
    //            _rooms[roomIndex.x, roomIndex.y].walls[2] = window;
    //        roomIndex.y--;
    //    }
    //}
    //private void PlaceStaticObjects()
    //{

    //    SpawnFloors();
    //    //CreateRoof();
    //    void SpawnFloors()
    //    {
    //        float height = 2.51f;
    //        int floorCount = 3;
    //        Vector3 floorPos = floorParent.transform.position;
    //        for (int i = 1; i <= floorCount; i++)
    //        {
    //            Instantiate(floorParent, new Vector3(floorPos.x, floorPos.y - i * height, floorPos.z), Quaternion.identity, transform);
    //        }
    //    }

    //    /*void CreateRoof()
    //    {
    //        for(int x = 0; x < _maxX; x++)
    //        {
    //            for(int y = 0; y < _maxY; y++)
    //            {
    //                GameObject currentRoof = Instantiate(roofPref, new Vector3(x * roomLengh, height, -y * roomLengh), Quaternion.identity, transform);
    //                if (_rooms[x, y])
    //                    _rooms[x, y].roof = currentRoof;
    //            }
    //        }
    //    }*/
    //}
    //private void SpawnFloors()
    //{
    //    float height = 2.51f;
    //    int floorCount = 3;
    //    Vector3 floorPos = _rooms[0,0].transform.position - new Vector3(6.25f, 0, -6.25f) ;
    //    for (int i = 0; i < floorCount; i++)
    //    {
    //        GameObject floor = Instantiate(floorPref, new Vector3(floorPos.x, floorPos.y - i * height, floorPos.z), Quaternion.identity, transform);
    //        floor.transform.localScale = new Vector3(_maxX, 1, _maxY);
    //    }
    //}

}