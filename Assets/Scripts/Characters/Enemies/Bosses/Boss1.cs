using UnityEngine;
namespace enemy
{
    [RequireComponent(typeof(Animator))]
    public class Boss1 : Boss
    {
        [SerializeField] private Animator animator;
        private int atackType = 0;
        bool _isMoving;
        bool isMoving
        {
            set
            {
                if (_isMoving != value)
                {
                    animator.SetBool("move", value);
                    _isMoving = value;
                }
            }
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
            isMoving = false;
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
            isMoving = true;
            transform.LookAt(Target);
        }
    }
}