using System.Collections;
using UnityEngine;
using UnityNightPool;
namespace enemy
{
    public class E_Fridge : SimpleEnemy
    {
        [SerializeField] private Animator hands;
        [SerializeField] private Animation door;

        [SerializeField] private Transform iceSpawn;
        [SerializeField] private Transform fridge;

        GameObject ice;
        private bool aiming;

        [SerializeField] private float minAtackDistance;

        [SerializeField] private float AngleInDegrees;
        private float currentAngleInDegrees;
        private Vector3 dir;
        private float AngleInRadians;

        private float g = Physics.gravity.y;
        private float x;
        private float y;
        private void Start()
        {
            SimpleEnemyStart();
        }
        private void Update()
        {
            SimpleEnemyUpdate();
            Rotate();
            if ((fromTo.magnitude > minAtackDistance && fromTo.magnitude < maxAtackDistance) && Entry)
            {
                aiming = true;
            }
            else
            {
                aiming = false;
            }

            if(!aiming)
            {
                if (Entry)
                {
                    if (fromTo.magnitude > (maxAtackDistance + minAtackDistance) / 2)
                        Move();
                }
                else
                    Move();

            }
            else if (Time.time > lastAtackTime + atackSpeed)
            {
                StartCoroutine(Shoot());
                lastAtackTime = Time.time;
            }
        }

        private void OnEnable()
        {
            SimpleEnemyOnEnable();
        }

        private void OnDisable()
        {
            SimpleEnemyOnDisable();
        }

        IEnumerator Shoot()
        {
            currentAngleInDegrees = fridge.localEulerAngles.x;
            while (currentAngleInDegrees <= AngleInDegrees)
            {
                currentAngleInDegrees += 120 * Time.deltaTime;
                dir = new Vector3(-currentAngleInDegrees, 0, 0);
                fridge.localEulerAngles = dir;
                yield return null;
            }
            door.Play("open");
            hands.SetBool("open", true);
            yield return new WaitForSeconds(0.5f);
            if(fromTo.magnitude > minAtackDistance && fromTo.magnitude < maxAtackDistance)
                ThrowIce();
            yield return new WaitForSeconds(0.5f);
            door.Play("close");
            hands.SetBool("open", false);
            while (fridge.rotation != transform.rotation)
            {
                dir = Vector3.RotateTowards(fridge.forward, transform.forward, 0.01f, Time.deltaTime);
                fridge.rotation = Quaternion.LookRotation(dir);
                yield return null;
            }
            yield break;
        }

        void ThrowIce()
        {
            x = fromToXZ.magnitude;
            y = fromTo.y;
            AngleInRadians = AngleInDegrees * Mathf.PI / 180;
            float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            ice = PoolManager.Get(11).gameObject;
            ice.transform.position = iceSpawn.position;
            ice.GetComponent<Rigidbody>().velocity = iceSpawn.forward * v;
        }
    }
}

