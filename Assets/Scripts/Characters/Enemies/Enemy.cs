using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    public abstract class Enemy : MonoBehaviour, IDieable
    {
        [SerializeField] protected float AtackSpeed = 1;
        [SerializeField] protected float MaxAtackDistance = 1;
        [SerializeField] protected float MoveSpeed = 50;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private ParticleSystem blood;

        public Image UIHP;

        protected IDamageable Player;
        protected Transform Target;
        protected float LastAtackTime;

        private Health _health;
        private IEnemiesHandler _enemiesHandler;
        private bool _inited;

        public void Init(IDamageable player, Transform target, IEnemiesHandler enemiesHandler)
        {
            if(_inited == false)
            {
                _health = new Health(_maxHealth, this);
                Player = player;
                Target = target;
                _enemiesHandler = enemiesHandler;
                _inited = true;
            }
            SetMaxHealth();
        }

        public void Enter()
        {
            _enemiesHandler.AddToList(this);
            OnEnter();
        }

        public void Die()
        {
            _enemiesHandler.RemoveFromList(this);
            OnDie();
        }

        public void ApplyDamage(int damage)
        {
            _health.ApplyDamage(damage);
            UIHP.fillAmount = (float)_health.Value / _maxHealth;
            blood.Play();
        }

        public virtual bool IsDamagable()
        {
            return true;
        }

        protected abstract void OnEnter();

        protected abstract void OnDie();

        private void SetMaxHealth() 
        { 
            _health.SetMaxValue();
            UIHP.fillAmount = 1;
        }
    }
}