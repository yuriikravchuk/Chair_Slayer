using UnityEngine;
using pool;
namespace enemy
{
    public class SimpleEnemy : Enemy
    {
        public PoolObject poolObject;

        protected Vector3 fromTo;
        protected Vector3 fromToXZ;
        protected Quaternion rot;
        public bool Entry = false;
        [SerializeField] private Collider coll;
        [SerializeField] private Rigidbody rigid;
        public int damage;

        private void OnDisable()
        {
            Entry = false;
            rigid.angularVelocity = Vector3.zero;
            rigid.velocity = Vector3.zero;
        }

        protected void OnUpdate()
        {
            Collider_Controller();
        }

        protected void TryRotate()
        {
            if(Entry)
            {
                fromTo = Target.position - transform.position;
                fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);
                rot = Quaternion.LookRotation(fromToXZ, Vector3.zero);
                transform.rotation = rot;
            }
        }

        protected void Collider_Controller()
        {
            if (Entry == false)
                coll.isTrigger = true;
            else
            {
                if (coll.isTrigger == true)
                    coll.isTrigger = false;
            }
        }

        protected void Move()
        {
            rigid.AddForce(transform.forward * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        public override void Die()
        {
            EnemiesManager.instance.RemoveFromList(this);
            poolObject.Return();
        }
    }
}