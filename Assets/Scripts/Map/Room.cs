using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]private GameObject roof;

    public Wall[] walls = new Wall[4];
    public bool Active { get; private set; }
    public bool Avaible { get; private set; }

    public void Activate()
    {
        Active = true;
        roof.SetActive(false);
        ShowWalls();
    }

    public void SetAvailable() => Avaible = true;
    public void ChangeTriggersActive(bool active)
    {
        for (int i = 0; i < 4; i++)
        {
            if (walls[i])
                walls[i].ChangeTriggerActive(active);
        }
    }

    private void ShowWalls()
    {
        for (int i = 0; i < 4; i++)
        {            
            if (walls[i])
            {
                if (walls[i].gameObject.activeSelf == false)
                    walls[i].Activate(this, Quaternion.Euler(0, 90 * (i + 1), 0));
                //else
                //    walls[i].HasRoomInBack = true;
            }
        }
    }
}