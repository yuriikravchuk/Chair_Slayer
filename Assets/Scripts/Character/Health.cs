public interface IDieable
{
    void Die();
}
public class Health
{
    public int Value { get; private set; }
    private readonly int _maxValue;
    private readonly IDieable _character;

    public Health(int maxValue, IDieable character)
    {
        _maxValue = maxValue;
        _character = character;
    }

    public void ApplyDamage(int damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            Value = 0;
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        Value += healAmount;
        if (Value > _maxValue)
            Value = _maxValue;
    }

    public void Reset()
    {
        Value = _maxValue;
    }

    private void Die()
    {
        _character.Die();
    }
}