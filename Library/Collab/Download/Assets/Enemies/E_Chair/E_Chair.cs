using UnityEngine;
using UnityNightPool;
namespace enemy
{
    public class E_Chair : Enemy
    {
        Quaternion rot;
        Transform target;
        private Vector3 direction;
        public Collider coll;
        public Rigidbody rigid;

        public PoolObject poolObject;



        public float speed;
        public bool entry = false;

        public const float damage = 10;

        void Start()
        {
            character = MapController.Instance.ch_Character;
            target = character.transform;
        }
        private void OnEnable()
        {
            Health = maxHealth;
            entry = false;
            lastAtackTime = 0;
        }

        private void OnDisable()
        {
            rigid.angularVelocity = Vector3.zero;
            rigid.velocity = Vector3.zero;
        }

        void FixedUpdate()
        {

            Collider_Controller();
            if (entry)
            {
                Rotate();
                rot = Quaternion.LookRotation(direction, Vector3.zero);
                transform.rotation = rot;

            }

            rigid.AddForce(transform.forward * speed / Time.deltaTime, ForceMode.Impulse);
            if (Vector3.Distance(transform.position, target.position) < atackDistance)
            {
                Hit();
            }

        }

        void Rotate()
        {
            direction.y = 0;                                            //rotate
            direction.x = target.position.x - transform.position.x;
            direction.z = target.position.z - transform.position.z;

        }
        private void Collider_Controller()
        {
            if (entry == false)
                coll.isTrigger = true;
            else
            {
                if (coll.isTrigger == true)
                    coll.isTrigger = false;
            }
        }

        void Hit()
        {
            if (Time.time > lastAtackTime + atackSpeed)
            {
                character.Health -= damage;
                Debug.Log("Health: " + character.Health);
                lastAtackTime = Time.time;
            }
        }


    }
}




