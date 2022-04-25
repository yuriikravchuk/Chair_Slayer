using UnityEngine;

[RequireComponent(typeof(Wall))]
public class Wall_Trigger : MonoBehaviour
{
    [SerializeField] private Wall _wall;
    private Breaker _player;
    private void OnTriggerEnter(Collider other)
    {
        _player = other.GetComponent<Breaker>();
        if (_player != null)
        {
            _player.SetWallToBrake(_wall);
            _player.transform.position = transform.position;
            _player.transform.rotation = transform.rotation;
            _player.SetBreakState();
        }
    }
}