using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : IDieable
{
    public UnityEvent Died;
    public bool isGuarded;
    private Image _canvasHealth;
    private Health _health;

    public Player(Image canvasHealth)
    {
        _canvasHealth = canvasHealth;
        _health = new Health(100, this);
    }
    public void TryTakeDamage(int damage)
    {
        if (!isGuarded)
            _health.ApplyDamage(damage);

        _canvasHealth.fillAmount = _health.Value / 100; //health on Canvas
    }

    public void Die()
    {
        //SaveManager.deathEvent.Invoke();
        Died.Invoke();
    }
}
