using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig")]
public class MapConfig : Config<MapConfig>
{
    [SerializeField] private BreakingWall _breakinggWall;
    [SerializeField] private GameObject _brokenWall;
    [SerializeField] private Room _room;
    [SerializeField] private Wall _wall;
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _floor;
    [Space(10)]
    [Header("Room Furniture")]
    [SerializeField] private GameObject _startRoom;
    [SerializeField] private GameObject _bossRoom;
    [SerializeField] private List<GameObject> _simpleRooms;

    public static BreakingWall WreckingWall => Instance._breakinggWall;
    public static GameObject BrokenWall => Instance._brokenWall;
    public static Room Room => Instance._room;
    public static Wall Wall => Instance._wall;
    public static GameObject Window => Instance._window;
    public static GameObject Floor => Instance._floor;
    public static GameObject StartRoomFurniture => Instance._startRoom;
    public static GameObject BossRoomFurniture => Instance._bossRoom;
    public static IEnumerable<GameObject> SimpleRoomsFurniture => Instance._simpleRooms;
}
