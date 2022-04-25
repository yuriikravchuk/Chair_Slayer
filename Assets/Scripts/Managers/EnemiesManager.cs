using UnityEngine;
using enemy;
using UnityEngine.Events;
public class EnemiesManager : Singleton<EnemiesManager>
{
    public static UnityEvent killEvent = new UnityEvent();
    public UnityEvent braveEvent = new UnityEvent();

    private Camera _mainCamera;
    private readonly KdTree<Enemy> _enemies = new KdTree<Enemy>();
    private readonly int[] _spawnChance = { 90, 101 };
    //0)Chair
    //1)Fridge

    public void Init(Camera mainCamera)
    {
        SaveManager.deathEvent.AddListener(ReturnAllEnemies);
        _mainCamera = mainCamera;
    }


    public Vector3 FindClosest(Vector3 playerPosition)
    {
        if (_enemies.Count > 0)
            return _enemies.FindClosest(playerPosition);
        else
            return playerPosition;
    }
    public void AddToList(Enemy current)
    {
        _enemies.Add(current);
        if(!(current is Boss))
        current.GetComponent<Canvas>().worldCamera = _mainCamera;
    }

    public void RemoveFromList(Enemy current)
    {
        BoostSpawner.instance.TrySpawn(current.transform.position);
        _enemies.RemoveAt(_enemies.ToList().IndexOf(current));
        if (current is Boss)
        {
            Destroy(current.gameObject);
            MenuManager.instance.Victory();
        }
        killEvent.Invoke();
    }

    public void ReturnAllEnemies() => PoolManager.ReturnAllEnemies();

    //public void SpawnBoss(Vector3 position, int level)
    //{
    //    Boss boss = Instantiate(BossConfig.bosses[level - 1]);
    //    boss.Init(_player, _target);
    //    boss.UIHP = MenuManager.instance.GreenHPBoss;
    //    boss.UIHP.fillAmount = 1;
    //    MenuManager.instance.ShowBossUIHP();
    //    AddToList(boss);
    //    boss.transform.position = position;
    //}

    //public SimpleEnemy GetEnemy()
    //{
    //    int random = Random.Range(1, 100);
    //    for(int i = 0; i < _spawnChance.Length; i++)
    //    {
    //        if(random <= _spawnChance[i])
    //        {
    //            SimpleEnemy enemy = PoolManager.Get(i + 1).GetComponent<SimpleEnemy>();
    //            enemy.Init(_player, _target);
    //            return enemy;
    //        }
    //    }
    //    return null;
    //}
}