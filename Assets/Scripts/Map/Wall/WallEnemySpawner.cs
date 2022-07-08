using UnityEngine;
using System.Collections;
using enemy;

public class WallEnemySpawner : MonoBehaviour
{
    [SerializeField] private Animator _door;
    [SerializeField] private Transform _spawn;

    public Vector3 SpawnPosition => _spawn.transform.position;
    public Quaternion SpawnRotation => _spawn.transform.rotation;


    public void Spawn(SimpleEnemy enemy)
    {
        enemy.transform.SetPositionAndRotation(SpawnPosition, SpawnRotation);
        StartCoroutine(GetEnemyIntoRoom(enemy));
    }

    private IEnumerator GetEnemyIntoRoom(SimpleEnemy enemy)
    {
        OpenDoor();
        yield return new WaitUntil(() =>
            Vector3.Distance(_spawn.position, enemy.transform.position) > 2.5);

        ReleaseEnemy(enemy);
        CloseDoor();
    }

    private void ReleaseEnemy(SimpleEnemy enemy)
    {
        enemy.Enter();
        //EnemiesManager.instance.AddToList(enemy);
    }

    private void OpenDoor() => _door.SetBool("open", true);
    private void CloseDoor() => _door.SetBool("open", false);
}
