using UnityEngine;
namespace enemy
{
    public class ChairEnemy : SimpleEnemy
    {
        private void Update()
        {
            OnUpdate();
            if (Vector3.Distance(transform.position, Target.position) < MaxAtackDistance)
            {
                TryHit();
            }
            Move();
            TryRotate();
 
        }

        private void TryHit()
        {
            if (Time.time > LastAtackTime + AtackSpeed)
            {
                Player.TryTakeDamage(damage);
                LastAtackTime = Time.time;
            }
        }
    }
}