using System.Collections;
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

    public static BreakingWall WreckingWall => Instance._breakinggWall;
    public static GameObject BrokenWall => Instance._brokenWall;
    public static Room Room => Instance._room;
    public static Wall Wall => Instance._wall;
    public static GameObject Window => Instance._window;
    public static GameObject Floor => Instance._floor;
}
