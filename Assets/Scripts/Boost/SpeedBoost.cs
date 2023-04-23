using System.Collections;
using UnityEngine;
using player;

public class SpeedBoost : Boost
{
    protected override void GiveBoost(Player player)
    {
       // Speed(player);
    }

    //private IEnumerator Speed(Player character)
    //{
    //    Animator animator = character.GetComponent<Animator>();
    //    animator.speed = 1.5f;
    //    Debug.Log("Speed: " + animator.speed);
    //    yield return new WaitForSeconds(BoostDuration);
    //    animator.speed = 1f;
    //    Debug.Log("Speed: " + animator.speed);
    //    yield break;
    //}
}
