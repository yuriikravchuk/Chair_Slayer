using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig")]
public class MapConfig : Config<MapConfig>
{
    [SerializeField] private GameObject _wreckingWall;
    [SerializeField] private GameObject _brokenWall;
    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _floor;

    public static GameObject WreckingWall => Instance._wreckingWall;
    public static GameObject BrokenWall => Instance._brokenWall;
    public static GameObject Room => Instance._room;
    public static GameObject Wall => Instance._wall;
    public static GameObject Window => Instance._window;
    public static GameObject Floor => Instance._floor;
}
