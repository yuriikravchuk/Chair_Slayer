using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorsBuilder : Object
{
    private readonly int _maxX, _maxY;
    private readonly float _roomHeight;
    public FloorsBuilder(int maxX, int maxY, float roomHeight)
    {
        _maxX = maxX;
        _maxY = maxY;
        _roomHeight = roomHeight;
    }
    public void Build(Vector3 position, int floorsCount)
    {
        for (int i = 0; i < floorsCount; i++)
        {
            GameObject floor = Instantiate(MapConfig.Floor, new Vector3(position.x, position.y - i * _roomHeight, position.z), Quaternion.identity);
            floor.transform.localScale = new Vector3(_maxX, 1, _maxY);
        }
    }
}
