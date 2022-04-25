using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class PlayerFacade : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private Image _canvasHealth;
    [SerializeField] private Animator _animator;
    [SerializeField] private Gun _gun;

    public bool IsGuarded;

    private PlayerStateMachine _stateMachine;
    private PlayerFire _fire;
    private Player _player;

    public void Init()
    {
        _fire = new PlayerFire(_gun);
        _stateMachine = new PlayerStateMachine(transform, _animator, _fire);
        _player = new Player(_canvasHealth);
    }

    public void SetMoveVector(Vector2 moveVector) =>
        _stateMachine.SetMoveVector(moveVector);

    public void SetDefaultState()
    {
        IsGuarded = false;
        _stateMachine.Brave = false;
    }

    public void SetBraveState()
    {
        IsGuarded = true;
        _stateMachine.Brave = true;
    }

    public void SetBreakState() => _animator.SetTrigger("break");

    public void SetAiming(bool value) =>
        _stateMachine.Aiming = value;

    public void SetMoving(bool value) =>
    _stateMachine.Moving = value;

    public void TryTakeDamage(int value)
    {
        if(IsGuarded)
            _player.TryTakeDamage(value);
    }

    public void TryFire() => _fire.TryFire();
    public void SetDoubleDamage()
    {

    }

    private void Update()
    {
        _stateMachine.TryUpdate();
    }
}