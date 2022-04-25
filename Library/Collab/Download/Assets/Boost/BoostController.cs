using UnityEngine;
using UnityNightPool;

public class BoostController : Singleton<BoostController>
{
    //List<Boost> activeBoosts;
    int random = 0;
    int spawnChance = 10;
    //speed = 31;
    //health = 61;
    //guard = 81;
    //double_damage = 101;
    readonly int[] boostChance = { 31, 61, 81, 101 };



    public void SpawnBoost(Transform spawn)
    {
        if(Random.Range(1, 101) < spawnChance)
        {
            random = Random.Range(1, 101);
            Boost boost = PoolManager.Get(3).GetComponent<Boost>();
            for (int i = 0; i < 4; i++)
            {
                if (random <= boostChance[i])
                {
                    boost.boostType = i;
                    boost.GetComponentInChildren<MeshRenderer>().material = boost.materials[i];
                    break;
                }
            }
            boost.transform.position = spawn.position;
        }
    }
}
