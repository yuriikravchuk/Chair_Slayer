using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B
{
    private Transform _transform;

    public B(Transform transform)
    {
        _transform = transform;
    }

    public void ChangeTransform()
    {
        _transform.Translate(new Vector3(0, 0, 1));
    }
}
