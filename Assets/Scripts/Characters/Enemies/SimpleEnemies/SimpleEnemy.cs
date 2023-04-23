using UnityEngine;
using pool;
namespace enemy
{
    public class SimpleEnemy : Enemy
    {
        [SerializeField] private PoolObject _poolObject;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float MoveSpeed = 50;

        protected bool Entry = false;
        public int Damage;

        protected Vector3 FromTo;
        protected Vector3 FromToXZ;
        protected Quaternion Rot;

        public override bool IsDamagable() => Entry;

        public override void Enter()
        { 
            Entry = true;
            _collider.isTrigger = false;
        }

        protected void TryRotate()
        {
            if(Entry)
            {
                FromTo = Target.position - transform.position;
                FromToXZ = new Vector3(FromTo.x, 0, FromTo.z);
                Rot = Quaternion.LookRotation(FromToXZ, Vector3.zero);
                transform.rotation = Rot;
            }
        }

        protected void Move()
            => _rigidbody.AddForce(MoveSpeed * Time.deltaTime * transform.forward, ForceMode.Impulse);

        protected override void OnDie()
        {
            Entry = false;
            _collider.isTrigger = true;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            _poolObject.Return();
        }

    }
}