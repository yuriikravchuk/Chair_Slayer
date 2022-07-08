using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private float smooth;

    public Transform player;

    private Vector3 velocity;

    private void FixedUpdate() => 
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref velocity, smooth);
}