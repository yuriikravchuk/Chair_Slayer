using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;     
    }

    void FixedUpdate()
    {
        transform.LookAt(target);
    }
}