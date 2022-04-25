using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Boost
{
    protected override void GiveBoost(PlayerFacade player)
    {
        Speed(player);
    }

    private IEnumerator Speed(PlayerFacade character)
    {
        Animator animator = character.GetComponent<Animator>();
        animator.speed = 1.5f;
        Debug.Log("Speed: " + animator.speed);
        yield return new WaitForSeconds(BoostDuration);
        animator.speed = 1f;
        Debug.Log("Speed: " + animator.speed);
        yield break;
    }
}
