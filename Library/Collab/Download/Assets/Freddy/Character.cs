using UnityEngine;
using UnityEngine.UI;
using enemy;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public Gun gun;
    public Rigidbody rigbody;
    public Collider coll;
    private Enemy target;

    private Vector3 moveVector;
    private Vector3 direction;
    private Vector3 movement;
    private Quaternion rot;

    private bool undying;
    public bool isGuarded;
    private bool aiming;
    public enum State { Default, Brave, Break };
    private State st = State.Default;
    public State state
    {
        get
        {
            return st;
        }
        set
        {
            st = value;
            switch (st)
            {
                case State.Brave:
                    rigbody.mass = 100;
                    undying = true;
                    break;

                case State.Break:
                    coll.isTrigger = true;
                    break;

                case State.Default:
                    rigbody.mass = 1;
                    undying = false;
                    coll.isTrigger = false;
                    break;
            }
        }
    }

    public float horizontal;
    public float vertical;
    public float speedRotate;
    private float forwardAmount;
    private float turnAmount;
    private float health = 100;
    [SerializeField] private Image CanvasHealth;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health > 0)
            {
                if (!undying && !isGuarded)
                    health = value;
                CanvasHealth.fillAmount = health / 100; //health on Canvas
            }
            else
                gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            anim.SetBool("aiming", true);
        }
        else if(Input.GetKeyUp("space"))
        {
            anim.SetBool("aiming", false);
        }
        moveVector = new Vector3(horizontal, 0, vertical);
        moveVector.Normalize();
        aiming = anim.GetBool("aiming");
       if(st != State.Break)
        {
            Rotate();
            Move(moveVector);
        }


    }

    private void Rotate()
    {     
        if (aiming)
        {
            target = gun.FindColsestEnemy();
            if (target != null && !undying)
            {
                movement = new Vector3(target.transform.position.x - transform.position.x, 0, target.transform.position.z - transform.position.z);
                direction = Vector3.RotateTowards(transform.forward, movement, speedRotate, 0);
                gun.Fire();
            }
        }
        else
        {
            if (Vector3.Angle(Vector3.forward, moveVector) > 1 || Vector3.Angle(Vector3.forward, moveVector) == 0)
                direction = Vector3.RotateTowards(transform.forward, moveVector, speedRotate, 0);
        }


        rot = Quaternion.LookRotation(direction);
        transform.rotation = rot;

    }

    private void Move(Vector3 move)
    {

            ConvertMoveInput();
            UpdateAnimator();
        }

    private void ConvertMoveInput()
        {
            Vector3 localMove = transform.InverseTransformDirection(moveVector);
            turnAmount = localMove.x;
            forwardAmount = localMove.z;
        }

    private void UpdateAnimator()
        {
            anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
            anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
        }     
    
}