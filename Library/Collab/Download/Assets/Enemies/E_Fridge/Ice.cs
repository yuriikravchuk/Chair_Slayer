using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    float radius = 2;
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].tag == "Character")
            {
                colliders[i].GetComponent<Character>();
            }
        }
    }
}
