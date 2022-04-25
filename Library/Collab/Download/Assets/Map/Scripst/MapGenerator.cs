using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Diagnostics;

public class MapGenerator : Manager<MapGenerator>
{
    private int maxX;
    private int maxY;

    public int roomCount;
    private const float roomLengh = 12.5f;

    public Room[,] rooms;
    // public List<Room> activeRooms;


    [SerializeField] private GameObject wreck_wall;
    private Animator wreck_anim;
    [SerializeField] private GameObject stat_wall;
    [SerializeField] private GameObject roomPref;
    [SerializeField] private GameObject wallPref;
    [SerializeField] private GameObject windowPref;
    [SerializeField] private GameObject floorPref;
    [SerializeField] private GameObject roofPref;
    [SerializeField] private Room spawnRoom;
    [SerializeField] private GameObject floorParent;

    public Character character;
    public Camera mainCam;



    private WallSpawner[] static_walls;

    private void Awake()
    {
        ManagerAwake();
    }
    private void Start()
    {
        roomCount = 50;
        CreateRooms();
        wreck_wall = Instantiate(wreck_wall);
        wreck_anim = wreck_wall.GetComponentInChildren<Animator>();
        wreck_wall.SetActive(false);
    }

    public void WreckWall(Transform wall)
    {
        wreck_wall.transform.position = wall.transform.position;
        wreck_wall.transform.rotation = wall.transform.rotation;
        wreck_wall.SetActive(true);
        Instantiate(stat_wall, wreck_wall.transform.position, wreck_wall.transform.rotation);
        ChangeTriggersActive(false);
        wreck_anim.SetBool("wrecking", true);
        Invoke("RestoreAfterWrecking", 4);  
    }
    private void RestoreAfterWrecking()
    {
        wreck_wall.SetActive(false);
        wreck_anim.SetBool("wrecking", false);
        ChangeEnemySpawnActive(true);
    }

    public void SetStateToBrave()
    {
        ChangeTriggersActive(true);
        character.anim.SetTrigger("brave");
        character.state = Character.State.Brave;
        ChangeEnemySpawnActive(false);
    }

    private void ChangeTriggersActive(bool current)
    {
        for (int x = 0; x < rooms.GetLength(0); x++)
        {
            for(int y = 0; y < rooms.GetLength(1); y++)
                if(rooms[x, y])
                    rooms[x, y].ChangeTriggersActive(current);
        }
    }

   /* if(activeRooms.Length % 3 == 0)
        {
            EnemiesManager.instance.SpawnBoss(rooms[roomIndex].transform, 1);
        }
    }*/

    public void ActivateNextRoom(Room currentRoom, WallObject currentWall)
    {
        int indexOfBrakedWall = Array.IndexOf(currentRoom.wallObjects, currentWall);
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                Room tempRoom = rooms[i, j];
                if (tempRoom && tempRoom.Equals(currentRoom))
                {
                    Room nextRoom = null;
                    int x = i, y = j;
                    switch (indexOfBrakedWall)
                    {
                        case 0:
                            x -= 1;
                            break;
                        case 1:
                            y -= 1;
                            break;
                        case 2:
                            x += 1;
                            break;
                        case 3:
                            y += 1;
                            break;
                        default:
                            UnityEngine.Debug.LogError("Can't find next room");
                            break;
                    }

                    int indexOfBrakedWallInNextRoom = -1;
                    if(indexOfBrakedWall > 2)
                        indexOfBrakedWallInNextRoom = indexOfBrakedWall - 2;
                    else
                        indexOfBrakedWallInNextRoom = indexOfBrakedWall + 2;

                    nextRoom = rooms[x, y];
                    if(nextRoom != null)
                    {
                        nextRoom.ActivateRoom();
                        PlaceWalls(x, y, indexOfBrakedWallInNextRoom);
                    }
                    else
                    {
                        UnityEngine.Debug.LogError("Room isn't founded");
                    }
                    return;

                }
            }
        }
    }

    private void PlaceWalls(int x, int y, int indexOfBrakedWall = 5)
    {
        Room currentRoom = rooms[x, y];
        int curX, curY , wallIndexInNextRoom, step = -1;

        for (int wallIndex = 0; wallIndex < 4; wallIndex++)
        {
            curX = x;
            curY = y; 
            wallIndexInNextRoom = -1;

            if (wallIndex % 2 == 0)
                curX += step;
            else
                curY += step;


            if (step < 0)
                wallIndexInNextRoom = wallIndex + 2;
            else
                wallIndexInNextRoom = wallIndex - 2;

            if (wallIndex == 1)
                step = -step;

            if (wallIndex == indexOfBrakedWall)
                continue;

            Room nextRoom = null;
            if (curX >= 0 && curX < maxX && curY >= 0 && curY < maxY)
                nextRoom = rooms[curX, curY];
            else
                continue;

                if (nextRoom && nextRoom.active)
                {
                    currentRoom.wallObjects[wallIndex] = nextRoom.wallObjects[wallIndexInNextRoom];
                    nextRoom.wallObjects[wallIndexInNextRoom].back = true;
                }
                else
                {
                    currentRoom.wallObjects[wallIndex] = Instantiate(wallPref, currentRoom.transform.position, Quaternion.Euler(0, 90 * (wallIndex + 1), 0), currentRoom.transform).GetComponent<WallObject>();
                    currentRoom.wallObjects[wallIndex].forward = currentRoom;
                }
        }

    }

    private void ChangeEnemySpawnActive(bool current)
    {
        Room currentRoom;

        for(int x = 0; x < rooms.GetLength(0); x++)
        {
            for(int y = 0; y < rooms.GetLength(1); y++)
            {
                if (rooms[x, y] && rooms[x,y].active)
                {
                    currentRoom = rooms[x, y];
                    for (int j = 0; j < 4; j++)
                    {
                        if (currentRoom.wallObjects[j])
                            currentRoom.wallObjects[j].SpawnActive = current;
                    }

                   /* static_walls = currentRoom.stat_obj?.GetComponentsInChildren<WallSpawner>();
                    for (int j = 0; j < static_walls.Length; j++)
                        static_walls[j].active = current;*/
                }
            }
        }
    }

    private void CreateRooms()
    {
        rooms = new Room[11, 11];
        int spawnX = 0;
        int spawnY = 0;
        rooms[spawnX, spawnY] = spawnRoom;
        maxX = rooms.GetLength(0);
        maxY = rooms.GetLength(1);

        for(int i = 0; i < roomCount; i++)
        {
            PlaceOneRoom();
        }
        GameObject floor = Instantiate(floorPref, new Vector3(-0.5f - spawnX, 0, -(-0.5f - spawnY)) * roomLengh, Quaternion.identity, floorParent.transform);
        floor.transform.localScale = new Vector3(11, 11, 11);
        character.transform.position = spawnRoom.transform.position;

        PlaceWindows();
        PlaceWalls(spawnX, spawnY);
        PlaceStaticObjects();
        spawnRoom.ActivateRoom();

        void PlaceOneRoom()
        {
            HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (!rooms[x, y])
                        continue;

                    if (x > 0 && !rooms[x - 1, y])
                        vacantPlaces.Add(new Vector2Int(x - 1, y));

                    if (y > 0 && !rooms[x, y - 1])
                        vacantPlaces.Add(new Vector2Int(x, y - 1));

                    if (x < maxX - 1 && !rooms[x + 1, y])
                        vacantPlaces.Add(new Vector2Int(x + 1, y));

                    if (y < maxY - 1 && !rooms[x, y + 1])
                        vacantPlaces.Add(new Vector2Int(x, y + 1));
                }
            }
            Vector2Int roomIndex = vacantPlaces.ElementAt(UnityEngine.Random.Range(0, vacantPlaces.Count));
            Room newRoom = Instantiate(roomPref, new Vector3(roomIndex.x - spawnX, 0, -(roomIndex.y - spawnY)) * roomLengh, Quaternion.identity, transform).GetComponent<Room>();
            rooms[roomIndex.x, roomIndex.y] = newRoom;
        }
        void PlaceWindows()
        {
            Vector2Int roomIndex = new Vector2Int(0, 0);
            WallObject window;
            for(int i = 0; i < maxX; i++)
            {
                roomIndex.y = 0;
                window = Instantiate(windowPref, new Vector3(roomIndex.x - spawnX, 0, -roomIndex.y + spawnY) * roomLengh, Quaternion.Euler(0, 180, 0), floorParent.transform).GetComponent<WallObject>();
                if (rooms[roomIndex.x, roomIndex.y])
                    rooms[roomIndex.x, roomIndex.y].wallObjects[1] = window;

                roomIndex.y = maxY - 1;

                window = Instantiate(windowPref, new Vector3(roomIndex.x - spawnX, 0, -roomIndex.y + spawnY) * roomLengh, Quaternion.Euler(0, 0, 0), floorParent.transform).GetComponent<WallObject>();
                if (rooms[roomIndex.x, roomIndex.y])
                    rooms[roomIndex.x, roomIndex.y].wallObjects[3] = window;
                roomIndex.x++;
            }

            for (int i = 0; i < maxY; i++)
            {
                roomIndex.x = maxX - 1;
                window = Instantiate(windowPref, new Vector3(roomIndex.x - spawnX, 0, -roomIndex.y + spawnY) * roomLengh, Quaternion.Euler(0, 270, 0), floorParent.transform).GetComponent<WallObject>();
                if (rooms[roomIndex.x, roomIndex.y])
                    rooms[roomIndex.x, roomIndex.y].wallObjects[0] = window;

                roomIndex.x = 0;
                window = Instantiate(windowPref, new Vector3(roomIndex.x - spawnX, 0, -roomIndex.y + spawnY) * roomLengh, Quaternion.Euler(0, 90, 0), floorParent.transform).GetComponent<WallObject>();
                if (rooms[roomIndex.x, roomIndex.y])
                    rooms[roomIndex.x, roomIndex.y].wallObjects[2] = window;
                roomIndex.y--;
            }
        }
    }

    private void PlaceStaticObjects()
    {
        float height = 2.51f;
        CreateFloors();
        CreateRoof();
        void CreateFloors()
        {      
            int floorCount = 3;
            Vector3 floorPos = floorParent.transform.position;
            for (int i = 1; i <= floorCount; i++)
            {
                Instantiate(floorParent, new Vector3(floorPos.x, floorPos.y - i * height, floorPos.z), Quaternion.identity, transform);
            }
        }

        void CreateRoof()
        {
            Vector2Int roofPos = new Vector2Int(0, 0);
            GameObject currentRoof;
            for(int x = 0; x < maxX; x++)
            {
                for(int y = 0; y < maxY; y++)
                {
                    currentRoof = Instantiate(roofPref, new Vector3(x * roomLengh, height, -y * roomLengh), Quaternion.identity, transform);
                    if (rooms[x, y])
                        rooms[x, y].roof = currentRoof;
                }
            }
        }
    }
}
