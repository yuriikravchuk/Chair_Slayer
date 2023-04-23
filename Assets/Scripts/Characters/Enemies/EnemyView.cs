using enemy;
using UnityEngine;

public abstract class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private ParticleSystem _blood;

    public void SetHealthAmount(float value)
    {
        healthBar.SetFillAmount(value);
        _blood.Play();
    }

    public void LookAt(Vector3 target)
        => transform.LookAt(target);

    public abstract void Move();
}
