using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : IDieable
{
    public event Action Died;
    public float Health => _health.Value;

    private readonly Health _health;

    public Player(int maxHealthValue) 
        => _health = new Health(maxHealthValue, this);

    public void ApplyDamage(int damage) 
        => _health.ApplyDamage(damage);

    public void Die() 
        => Died?.Invoke();
}