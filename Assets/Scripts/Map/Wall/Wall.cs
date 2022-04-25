using UnityEngine;
using enemy;
using System.Collections;

public class Wall : MonoBehaviour
{
    [SerializeField] private Animator _door;
    [SerializeField] private Wall_Trigger _trigger;
    [SerializeField] private Transform _spawn;

    public Room ForwardRoom { get; private set; }
    public bool HasRoomInBack;
    public Vector3 SpawnPosition => _spawn.transform.position;
    public Quaternion SpawnRotation => _spawn.transform.rotation;

    public void ChangeTriggerActive(bool active) => _trigger.gameObject.SetActive(active);

    public void Activate(Room currentRoom, Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        ForwardRoom = currentRoom;
        gameObject.SetActive(true);
    }

    public void OpenDoorForEnemy(SimpleEnemy enemy)
    {
        _door.SetBool("open", true);
        StartCoroutine(WaitUntilEnemyEntryRoom(enemy));
    }

    private IEnumerator WaitUntilEnemyEntryRoom(SimpleEnemy enemy)
    {
        yield return new WaitUntil(() => 
            Vector3.Distance(_spawn.position, enemy.transform.position) > 2.5);

        ReleaseEnemy(enemy);
        _door.SetBool("open", false);
    }

    private void ReleaseEnemy(SimpleEnemy enemy)
    {
        enemy.Entry = true;
        EnemiesManager.instance.AddToList(enemy);
    }
}