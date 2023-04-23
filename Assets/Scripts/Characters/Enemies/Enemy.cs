using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float AtackSpeed = 1;
        [SerializeField] protected float MaxAtackDistance = 1;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private ParticleSystem _blood;
        [SerializeField] private Image _UIHP;

        protected IDamageable Player;
        protected Transform Target;
        protected float LastAtackTime;

        private Health _health;
        private EnemiesFactory _fabric;
        private bool _inited;

        public void Init(IDamageable player, Transform target, EnemiesFactory enemiesHandler)
        {
            if(_inited == false)
            {
                _health = new Health(_maxHealth);
                _health.Died += Die;
                Player = player;
                Target = target;
                _fabric = enemiesHandler;
                _inited = true;
            }
            SetMaxHealth();
        }

        public void Die()
        {
            _fabric.Return(this);
            OnDie();
        }

        public void ApplyDamage(int damage)
        {
            _health.ApplyDamage(damage);
            _UIHP.fillAmount = (float)_health.Value / _maxHealth;
            _blood.Play();
        }

        public virtual bool IsDamagable() => true;

        public abstract void Enter();

        protected abstract void OnDie();

        private void SetMaxHealth() 
        { 
            _health.SetMaxValue();
            _UIHP.fillAmount = 1;
        }
    }
}