using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    public class Boss1 : Boss
    {
        Animator animator;
        Transform target;
        int atackType = 0;
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
            health = maxHealth;
            character = MapController.Instance.ch_Character;
            target = character.transform;
            animator = GetComponent<Animator>();
            atackDistance = 2.3f;
            atackSpeed = 2.5f;
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, target.position) > atackDistance)
                Move();
            else if (lastAtackTime + atackSpeed < Time.time)
                Atack();
        }

        void Atack()
        {
            transform.LookAt(target);
            move = false;
            atackType = Random.Range(1, 4);
            Debug.Log(atackType);
            if (atackType > 0)
            {
                animator.SetInteger("atackType", atackType);
                animator.SetTrigger("atack");
                atackType = 0;
                lastAtackTime = Time.time;
            }
        }

        private void Move()
        {
            move = true;
            transform.LookAt(target);
        }
    }
}

