using UnityEngine;

public class WallsGenerator : Object
{
    public void Spawn(Room[,] rooms)
    {
        int _maxX = rooms.GetLength(0);
        int _maxY = rooms.GetLength(1);
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                Room currentRoom = rooms[x, y];
                if(currentRoom)
                {
                    if (isLeftBound(x) == false)
                    {
                        currentRoom.walls[0] = SpawnWall(currentRoom.transform, 0);
                        if (rooms[x - 1, y])
                            rooms[x - 1, y].walls[2] = currentRoom.walls[0];
                    }

                    if(isTopBound(y) == false)
                    {
                        currentRoom.walls[1] = SpawnWall(currentRoom.transform, 1);
                        if (rooms[x, y-1])
                            rooms[x, y-1].walls[3] = currentRoom.walls[1];
                    }
                }
            }
        }
    }

    private Wall SpawnWall(Transform currentRoom, int wallIndex)
    {
        Wall wall = Instantiate(MapConfig.Wall, currentRoom.transform.position, Quaternion.Euler(0, 90 * (wallIndex + 1), 0), currentRoom).GetComponent<Wall>();
        return wall;
    }


    private bool isLeftBound(int x) => x == 0;
    private bool isTopBound(int y) => y == 0;
}
