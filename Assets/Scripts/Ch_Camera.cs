using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Camera : MonoBehaviour
{

    public Transform player;
    public float smooth;
    Vector3 velocity = Vector3.zero;
    Vector3 pos = new Vector3();

    void FixedUpdate()
    {
        pos.x = player.position.x;
        pos.z = player.position.z;
        pos.y = player.position.y;// + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}