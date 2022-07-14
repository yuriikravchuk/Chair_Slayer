using playerStateMachine;
using System;
using UnityEngine;

public class PlayerFacade : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private Gun _gun;

    private const int MAX_HEALTH_VALUE = 100;
    private PlayerState _state;

    public bool IsGuarded = false;

    private PlayerFire _fire;
    private Player _model;

    private void Update()
    {
        _state.Update();

        if(_state.CanFire())
            _fire.TryFire();
    }
    public void Init(IClosestTargetFinder targetFinder)
    {
        _model = new Player(MAX_HEALTH_VALUE);
        _view.Init(targetFinder);
        _fire = new PlayerFire(_gun);
    }

    public void SetState(PlayerState state) 
        => _state = state ?? throw new NullReferenceException();

    public void TryTakeDamage(int damage)
    {
        if (_state.IsDamagable() == false)
            return;

        _model.ApplyDamage(damage);
        UpdateView();
    }

    private void UpdateView()
        => _view.SetHealth(_model.Health / MAX_HEALTH_VALUE);
}