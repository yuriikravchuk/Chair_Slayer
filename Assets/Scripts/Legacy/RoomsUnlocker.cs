using UnityEngine;
using System;

public class RoomsUnlocker : UnityEngine.Object, IRoomUnlocker
{
    //private Room[,] _rooms;
    //private readonly int _maxX;
    //private readonly int _maxY;
    //public RoomsUnlocker(Room[,] rooms, Breaker breaker)
    //{
    //    _rooms = rooms;
    //    _maxX = _rooms.GetLength(0);
    //    _maxY = _rooms.GetLength(1);
    //    //breaker.BreakWallEvent += ActivateNextRoom;
    //}

    public void ActivateNextRoom(Wall brakedWall)
    {
        //Room currentRoom = brakedWall.ForwardRoom;
        //int indexOfBrakedWall = FindWallIndex(currentRoom, brakedWall);
        //Vector2Int indexOfCurrentRoom = FindRoomIndex(currentRoom);
        //int x = indexOfCurrentRoom.x, y = indexOfCurrentRoom.y;
        //switch (indexOfBrakedWall)
        //{
        //    case 0:
        //        x -= 1;
        //        break;
        //    case 1:
        //        y -= 1;
        //        break;
        //    case 2:
        //        x += 1;
        //        break;
        //    case 3:
        //        y += 1;
        //        break;
        //    default:
        //        UnityEngine.Debug.LogError("Can't find next room");
        //        break;
        //}

        //int indexOfBrakedWallInNextRoom = FindWallIndexInNextRoom(indexOfBrakedWall);

        //Room nextRoom = _rooms[x, y];
        Room nextRoom = brakedWall.BackwardRoom;

        if (nextRoom.Avaible)
            nextRoom.Activate();
    }

    //private Vector2Int FindRoomIndex(Room room)
    //{
    //    for (int x = 0; x < _maxX; x++)
    //    {
    //        for (int y = 0; y < _maxY; y++)
    //        {
    //            if (_rooms[x, y].Equals(room))
    //                return new Vector2Int(x, y);
    //        }
    //    }

    //    throw new InvalidOperationException();
    //}

    //private int FindWallIndex(Room room, Wall wall) 
    //    => Array.IndexOf(room.walls, wall);

    //private int FindWallIndexInNextRoom(int wallIndexInCurrentRoom)
    //{
    //    if (wallIndexInCurrentRoom > 2)
    //        return wallIndexInCurrentRoom - 2;
    //    else
    //        return wallIndexInCurrentRoom + 2;
    //}

}

public interface IRoomUnlocker
{
    void ActivateNextRoom(Wall wall);
}