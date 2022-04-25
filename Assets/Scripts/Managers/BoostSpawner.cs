using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BoostSpawner : Singleton<BoostSpawner>
{
    [SerializeField] private List<Boost> _boosts;

    private int _spawnChance = 6;
    //private const int _countOfBoosts = 4;
    //private int[] _boostChance = { 31, 33, 81, 101 };

    public void TrySpawn(Vector3 position)
    {
        if(Random.Range(1, 101) < _spawnChance)
        {
            GetBoost(position);
        }
    }

    private void GetBoost(Vector3 position)
    {
        Boost boost = _boosts[Random.Range(0, _boosts.Count)];
        Instantiate(boost);
        boost.transform.position = position;
            //if (Random.Range(1, 101) <= _boostChance[i])
            //{
            //    //Boost boost = PoolManager.Get(i + 50).GetComponent<Boost>();

            //    boost.transform.position = position;
            //    break;
            //}
    }


    //public void GiveBoost(int boostType, PlayerModel character)
    //{
    //    switch (boostType)
    //    {
    //        case 0:
    //            StartCoroutine(Speed(character));
    //            break;
    //        case 1:
    //            Heal(character);
    //            break;
    //        case 2:
    //            StartCoroutine(Guard(character));
    //            break;
    //        case 3:
    //            StartCoroutine(Double_Damage(character));
    //            break;
    //    }
    //}

    //private IEnumerator Double_Damage(PlayerModel character)
    //{
    //    Gun gun = character.GetComponent<PlayerModel>().gun;
    //    int damage = gun.Damage;
    //    gun.Damage = damage * 2;
    //    yield return new WaitForSeconds(_dd_time);
    //    gun.Damage = damage;
    //    yield break;
    //}

    //private IEnumerator Guard(PlayerMovement character)
    //{
    //    //if (!character.isGuarded)
    //    //{
    //        //character.isGuarded = true;
    //        yield return new WaitForSeconds(_g_time);
    //        //character.isGuarded = false;
    //    //}
    //    yield break;
    //}

    //private void Heal(PlayerMovement character)
    //{
    //    //character.TryTakeDamage(-10);
    //}

    //private IEnumerator Speed(PlayerModel character)
    //{
    //    Animator animator = character.GetComponent<Animator>();
    //    animator.speed = 1.5f;
    //    Debug.Log("Speed: " + character.GetComponent<Animator>().speed);
    //    yield return new WaitForSeconds(_s_time);
    //    animator.speed = 1f;
    //    Debug.Log("Speed: " + character.GetComponent<Animator>().speed);
    //    yield break;
    //}
}