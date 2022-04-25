using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    private B _b;
    void Start()
    {
        _b = new B(transform);
    }

    // Update is called once per frame
    void Update()
    {
        _b.ChangeTransform();
    }
}
