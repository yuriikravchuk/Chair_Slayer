using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageBoost : Boost
{
    protected override void GiveBoost(PlayerFacade player)
    {
        //Guard(player);
    }

    //private IEnumerator Double_Damage(PlayerFacade player)
    //{
    //    Gun gun = character.GetComponent<PlayerModel>().gun;
    //    int damage = gun.Damage;
    //    gun.Damage = damage * 2;
    //    yield return new WaitForSeconds(_dd_time);
    //    gun.Damage = damage;
    //    yield break;
    //}
}
