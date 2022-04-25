using UnityNightPool;
using UnityEngine;
namespace enemy
{
    public class SimpleEnemy : Enemy
    {
        public PoolObject poolObject;
        protected Transform  target;
        ///protected Vector3 direction;
        protected Vector3 fromTo;
        protected Vector3 fromToXZ;
        protected Quaternion rot;
        public bool Entry = false;
        [SerializeField] private Collider coll;
        [SerializeField] private Rigidbody rigid;
        public float damage;
        protected void SimpleEnemyStart()
        {
            character = GameConfig.instance.character;
            target = character.transform;
        }

        protected void SimpleEnemyOnEnable()
        {
            Health = maxHealth;
            lastAtackTime = Time.time;
        }
        protected void SimpleEnemyOnDisable()
        {
            Entry = false;
            rigid.angularVelocity = Vector3.zero;
            rigid.velocity = Vector3.zero;
        }

        protected void SimpleEnemyUpdate()
        {
            Collider_Controller();
        }

        protected void Rotate()
        {
            if(Entry)
            {
                fromTo = target.position - transform.position;
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
            rigid.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}


