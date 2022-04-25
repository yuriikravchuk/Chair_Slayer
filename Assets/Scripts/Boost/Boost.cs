using UnityEngine;
using pool;

public abstract class Boost : MonoBehaviour
{
    public PoolObject poolObject;
    protected int BoostDuration = 15;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerFacade>() != null)
        {
            GiveBoost(other.GetComponent<PlayerFacade>());
            Destroy(gameObject);
//          BoostController.instance.GiveBoost(boostType, other.GetComponent<PlayerModel>());
            //poolObject.Return();
        }
    }

    protected abstract void GiveBoost(PlayerFacade player);
}
