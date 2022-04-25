using UnityEngine;
namespace enemy
{
    [RequireComponent(typeof(Animator))]
    public class Boss1 : Boss
    {
        private Animator animator;
        private int atackType = 0;
        bool _move;
        bool move
        {
            set
            {
                if (_move != value)
                {
                    animator.SetBool("move", value);
                    _move = value;
                }
            }
        }

        void OnEnable()
        {
            animator = GetComponent<Animator>();
            MaxAtackDistance = 2.3f;
            AtackSpeed = 2.5f;
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, Target.position) > MaxAtackDistance)
                Move();
            else if (LastAtackTime + AtackSpeed < Time.time)
                Atack();
        }

        void Atack()
        {
            transform.LookAt(Target);
            move = false;
            atackType = Random.Range(1, 4);
            if (atackType > 0)
            {
                animator.SetInteger("atackType", atackType);
                animator.SetTrigger("atack");
                atackType = 0;
                LastAtackTime = Time.time;
            }
        }

        private void Move()
        {
            move = true;
            transform.LookAt(Target);
        }
    }
}