using UnityEngine;
using enemy;

public class WallSpawner : WallObject
{
    public Animator door;
    public Wall_Trigger trigger;
    void FixedUpdate()
    {
        SpawnController();

        if (enemy && Vector3.Distance(spawn.transform.position, enemy.transform.position) > 2.5)
            CloseDoor();
    }

    public void SpawnController()
    {
        if (SpawnActive && Time.time > spawnTime + spawnSpeed)
        {
            SpawnEnemy();
            spawnTime = Time.time;
            door.SetBool("open", true);
        }
    }

    void CloseDoor()
    {
        if (enemy && !enemy.Entry)
        {
            enemy.Entry = true;
            AddToList(enemy);
        }
        door.SetBool("open", false);
        enemy = null;
    }



    private void OnEnable()
    {
        WallObjectOnEnable();
    }
    private void OnDisable()
    {
        CloseDoor();
        WallObjectOnDisable();
    }
}
    

