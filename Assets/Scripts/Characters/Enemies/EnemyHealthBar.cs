using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _UIHP;

    private Transform _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>().transform;     
    }

    private void FixedUpdate()
    {
        transform.LookAt(_camera);
    }

    public void SetFillAmount(float amount)
    {
        if (amount > 1 || amount < 0) throw new ArgumentOutOfRangeException();

        _UIHP.fillAmount = amount;
    }
}