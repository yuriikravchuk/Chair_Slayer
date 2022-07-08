using UnityEngine;

[RequireComponent(typeof(WallEnemySpawner))]
public class Wall : MonoBehaviour
{
    [SerializeField] private WallTrigger _trigger;
    [SerializeField] private WallEnemySpawner _enemySpawner;

    public Room BackwardRoom { get; private set; }
    public WallEnemySpawner EnemySpawner => _enemySpawner;
    public bool HasRoomInBack => BackwardRoom.Active;

    private Room _forwardRoom;

    public void Init(Room forwardRoom, Room backwardRoom)
    {
        _forwardRoom = forwardRoom;
        BackwardRoom = backwardRoom;
    }

    public void Activate(Room forwardRoom, Quaternion rotation)
    {
        transform.SetPositionAndRotation(forwardRoom.transform.position, rotation);

        if (BackwardRoom.Equals(forwardRoom))
            SwitchRooms();

        gameObject.SetActive(true);
    }

    public void ChangeTriggerActive(bool active) => _trigger.gameObject.SetActive(active);

    public void SwitchRooms()
    {
        Room temp = _forwardRoom;
        _forwardRoom = BackwardRoom;
        BackwardRoom = temp;
    }
}