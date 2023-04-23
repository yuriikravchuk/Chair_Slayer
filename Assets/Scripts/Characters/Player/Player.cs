using System;

namespace player
{
    public class Player : IDamageable
    {
        public event Action Died;
        public event Action<float> HealthChanged;

        private PlayerState _state;
        private readonly Health _health;
        private readonly IClosestTargetFinder _targetFinder;

        public Player(int healthValue, PlayerState startState)
        {
            _health = new Health(healthValue);
            _health.Died += Die;
            SetState(startState);
        }

        public void SetState(PlayerState state)
            => _state = state;

        public void TryTakeDamage(int damage)
        {
            if(_state.IsDamageable())
            {
                _health.ApplyDamage(damage);
                HealthChanged.Invoke(_health.Value);
            }
        }

        private void Die()
        {
            Died.Invoke();
        }
    }
}