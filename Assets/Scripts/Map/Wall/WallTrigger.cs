using UnityEngine;

[RequireComponent(typeof(Wall))]
public class WallTrigger : MonoBehaviour
{
    [SerializeField] private Wall _wall;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<WallWrecker>();
        if (player != null)
        {
            player.transform.SetPositionAndRotation(transform.position, transform.rotation);
            player.StartWrecking(_wall);
        }
    }
}