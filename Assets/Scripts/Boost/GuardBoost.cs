using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBoost : Boost
{
    protected override void GiveBoost(PlayerFacade player)
    {
        Guard(player);
    }

    private IEnumerator Guard(PlayerFacade player)
    {
        if (!player.IsGuarded)
        {
            player.IsGuarded = true;
            yield return new WaitForSeconds(BoostDuration);
            player.IsGuarded = false;
        }
        yield break;
    }
}
