using playerStateMachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class PlayerFacade : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private Gun _gun;

    private const int MAX_HEALTH_VALUE = 100;

    public bool IsGuarded = false;

    private PlayerMovementStateMachine _stateMachine;
    private PlayerFire _fire;
    private Player _model;


    private void Update()
    {
        _stateMachine.UpdateCurrentState();

        if(_stateMachine.CanFire())
            _fire.TryFire();
    }
    public void Init(IClosestTargetFinder targetFinder)
    {
        _model = new Player(MAX_HEALTH_VALUE);
        _view.Init(targetFinder);
        _stateMachine = new PlayerMovementStateMachine(_view);
        _fire = new PlayerFire(_gun);
    }

    public void SetMoveVector(Vector2 moveVector) 
        => _stateMachine.SetMoveVector(moveVector);

    public void TryTakeDamage(int damage)
    {
        if (IsGuarded)
            return;

        _model.ApplyDamage(damage);
        UpdateView();
    }

    public void SetDefaultState()
    {
        IsGuarded = false;
        _stateMachine.SetRootState<DefaultState>();
    }

    public void SetBraveState()
    {
        IsGuarded = true;
        _stateMachine.SetRootState<BraveState>();
    }

    public void SetBreakState() 
        => _stateMachine.SetRootState<BreakState>();

    public void StartAiming()
        => _stateMachine.StartAiming();

    public void StopAiming()
        => _stateMachine.StopAiming();

    public void StartMoving() 
        => _stateMachine.StartMoving();

    public void StopMoving()
        => _stateMachine.StopMoving();

    public void TryFire() 
        => _fire.TryFire();

    private void UpdateView()
        => _view.SetHealth(_model.Health / MAX_HEALTH_VALUE);
}