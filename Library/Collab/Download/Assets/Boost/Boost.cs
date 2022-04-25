using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityNightPool;

public class Boost : MonoBehaviour
{
    public PoolObject poolObject;
    Character character;
    public int boostType = -1;
    public Material[] materials;
    public int dd_time = 15;
    public int g_time = 15;
    public int s_time = 15;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            character = MapController.Instance.ch_Character;
            GiveBoost();
            poolObject.Return();
        }
    }

    void GiveBoost()
    {
        switch (boostType)
        {
            case 0:
                StartCoroutine(Speed());
                break;
            case 1:
                Health();
                break;
            case 2:
                StartCoroutine(Guard());
                break;
            case 3:
                StartCoroutine(Double_Damage());
                break;
        }
    }

    private IEnumerator Double_Damage()
    {
        float damage = character.GetComponent<Gun>().damage;
        character.GetComponent<Gun>().damage = damage * 2;
        yield return new WaitForSeconds(dd_time);
        character.GetComponent<Gun>().damage = damage;
    }

    private IEnumerator Guard()
    {
        if (!character.undying)
        {
            character.undying = true;
            yield return new WaitForSeconds(g_time);
            character.undying = false;
        }
    }

    private void Health()
    {
        character.Health += 10;
    }

    private IEnumerator Speed()
    {
        character.GetComponent<Animator>().speed = 1.5f;
        yield return new WaitForSeconds(s_time);
        character.GetComponent<Animator>().speed = 1f;
    }
}
