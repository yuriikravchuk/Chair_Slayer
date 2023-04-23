using UnityEngine;

public class SimpleEnemyView : EnemyView
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;
    
    private float MoveSpeed = 50;

    public override void Move()
        => _rigidbody.AddForce(MoveSpeed * Time.deltaTime * transform.forward, ForceMode.Impulse);
}
