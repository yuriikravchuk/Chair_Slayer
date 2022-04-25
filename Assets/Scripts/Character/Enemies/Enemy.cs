using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    public abstract class Enemy : MonoBehaviour, IDieable
    {
        [SerializeField] protected float AtackSpeed;
        [SerializeField] protected float MaxAtackDistance;
        [SerializeField] protected float MoveSpeed;
        [SerializeField] private int _maxHealth;

        public Image UIHP;
        protected IDamageable Player;
        protected Transform Target;
        protected float LastAtackTime;

        private Health _health;

        public void Init(IDamageable player, Transform target)
        {
            if (_health == null)
                _health = new Health(_maxHealth, this);

            ResetHealth();
            Player = player;
            Target = target;
        }

        public void ApplyDamage(int damage)
        {
            _health.ApplyDamage(damage);
            UIHP.fillAmount = _health.Value / _maxHealth;
        }

        public abstract void Die();

        private void ResetHealth() 
        { 
            _health.Reset();
            UIHP.fillAmount = 1;
        }
    }
}