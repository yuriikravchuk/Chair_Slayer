using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]private GameObject _roof;

    public Wall[] Walls = new Wall[_wallsCount];
    public bool Active { get; private set; }
    public bool Avaible { get; private set; }

    private const int _wallsCount = 4;
    private readonly List<GameObject> _staticObjects = new List<GameObject>();
    public void Activate()
    {
        Active = true;
        _roof.SetActive(false);
        ShowWalls();
        ShowStaticObjects();
    }

    public void SetAvailable() => Avaible = true;
    public void ChangeTriggersActive(bool active)
    {
        for (int i = 0; i < _wallsCount; i++)
            Walls[i]?.ChangeTriggerActive(active);

    }

    public void AddStaticObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        _staticObjects.Add(gameObject);
    }

    public void ShowStaticObjects()
    {
        foreach (GameObject gameObject in _staticObjects)
            gameObject.SetActive(true);       
    }

    private void ShowWalls()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Walls[i])
            {
                if (Walls[i]?.gameObject.activeSelf == false)
                    Walls[i].Activate(this, Quaternion.Euler(0, 90 * (i + 1), 0));
                //else
                //    walls[i].HasRoomInBack = true;
            }
        }
    }


}