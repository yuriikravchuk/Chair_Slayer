using UnityEngine;

public class Room : MonoBehaviour
{
    public WallObject[] wallObjects = new WallObject[4];
    //public GameObject stat_obj;
    public GameObject roof;
    public bool active { get; private set; }
    public void ChangeTriggersActive(bool current)
    {
        for(int i = 0; i < 4; i++)
        {
            WallSpawner temp = wallObjects[i] as WallSpawner;
            if(temp)
            {
                temp.trigger.gameObject.SetActive(current);
                Debug.Log(1);
            }

        }
    }

    public void ActivateRoom()
    {
        roof.SetActive(false);
        active = true;
        //stat_obj?.SetActive(true);
    }
}
