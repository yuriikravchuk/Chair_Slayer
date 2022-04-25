using UnityEngine;
using enemy;
public class WallObject : MonoBehaviour
{
    public Room forward = null;
    private bool active = false;

    public bool back;
    protected SimpleEnemy enemy = null;
    public GameObject spawn;
    protected float spawnTime;
    protected int spawnSpeed = 7;
    public bool SpawnActive
    {
        get
        {
            return active;
        }
        set
        {
            if (!back)
                active = value;
            else
                active = false;
        }
    }

    protected void SpawnEnemy()
    {
        enemy = EnemiesManager.instance.GetEnemy();
        enemy.transform.position = spawn.transform.position;
        enemy.transform.rotation = spawn.transform.rotation;
    }

    protected void WallObjectOnEnable()
    {
        SpawnActive = true;
        spawnTime = Time.time;
    }

    protected void WallObjectOnDisable()
    {
        SpawnActive = false;
    }

    protected void AddToList(Enemy current)
    {
        EnemiesManager.instance.AddToList(current);
    }
}
