using UnityEngine;
using pool;
using player;

public abstract class Boost : MonoBehaviour
{
    public PoolObject poolObject;
    protected int BoostDuration = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            GiveBoost(other.GetComponent<Player>());
            Destroy(gameObject);
//          BoostController.instance.GiveBoost(boostType, other.GetComponent<PlayerModel>());
            //poolObject.Return();
        }
    }

    protected abstract void GiveBoost(Player player);
}
