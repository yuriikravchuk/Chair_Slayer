using System.Collections;
using UnityEngine;
using player;

public class GuardBoost : Boost
{
    protected override void GiveBoost(Player player)
    {
        Guard(player);
    }

    private IEnumerator Guard(Player player)
    {
        //if (!player.IsGuarded)
        //{
        //    player.IsGuarded = true;
        //    yield return new WaitForSeconds(BoostDuration);
        //    player.IsGuarded = false;
        //}
        yield break;
    }
}
