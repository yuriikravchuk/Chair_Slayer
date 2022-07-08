using System;

public interface IDieable
{
    void Die();
}
public class Health
{
    public float Value { get; private set; }
    private readonly int _maxValue;
    private readonly IDieable _character;

    public Health(int maxValue, IDieable character)
    {
        _maxValue = maxValue;
        _character = character;
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Value -= damage;
        if (Value <= 0)
        {
            Value = 0;
            _character.Die();
        }
    }

    public void Heal(int healAmount)
    {
        Value += healAmount;
        if (Value > _maxValue)
            Value = _maxValue;
    }

    public void SetMaxValue()
    {
        Value = _maxValue;
    }
}