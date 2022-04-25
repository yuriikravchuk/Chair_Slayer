using UnityEngine;
using UnityNightPool;
using enemy;
public class EnemiesManager : Singleton<EnemiesManager>
{
    public KdTree<Enemy> enemies = new KdTree<Enemy>();
    public int killCount = 0;
    readonly private int[] enemySpawnChance = { 90, 101 };
    private int random = 0;
    //0)Chair
    //1)Fridge
    private void Update()
    {
        if (killCount >= 10)
        {
            killCount = 0;
            MapGenerator.instance.SetStateToBrave();
        }
    }

    public Enemy FindClosestEnemy(Transform spawn)
    {
        if (enemies.Count > 0)
            return enemies.FindClosest(spawn.transform.position);
        else
            return null;
    }
    public void AddToList(Enemy current)
    {
        enemies.Add(current);
        if(!(current is Boss))
        current.GetComponent<Canvas>().worldCamera = GameConfig.instance.cam.GetComponentInChildren<Camera>();
    }

    public void RemoveFromList(Enemy current)
    {
        BoostController.instance.SpawnBoost(current.transform);
        enemies.RemoveAt(enemies.ToList().IndexOf(current));
        if (current is E_Chair)
            ((E_Chair)current).poolObject.Return();
        else
        {
            Destroy(current.gameObject);
            SetBossUIHP(false);
        }


        killCount++;
    }

    public void SpawnBoss(Transform current, int level)
    {
        Boss boss = Instantiate(BossConfig.bosses[level - 1]);
        boss.UIHP = MenuManager.instance.GreenHPBoss;
        boss.UIHP.fillAmount = 1;
        SetBossUIHP(true);
        AddToList(boss);
        boss.transform.position = current.position;
    }
    public void SetBossUIHP(bool current)
    {
        MenuManager.instance.UIHPBoss.SetActive(current);
    }

    public SimpleEnemy GetEnemy()
    {
        random = Random.Range(1, 101);
        for(int i = 0; i < enemySpawnChance.Length; i++)
        {
            if(random < enemySpawnChance[i])
            {
                return PoolManager.Get(i+1).GetComponent<SimpleEnemy>();
            }
        }
        return null;
    }
}
