using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public bool Aiming;
    public bool Moving;
    public bool Brave;

    private readonly Transform _transform;
    private readonly Animator _animator;
    private readonly List<PlayerState> _allStates;
    private PlayerState _currentState;
    //private Vector3 _moveVector;
    public bool Enabled = true;

    public PlayerStateMachine(Transform transform, Animator animator, PlayerFire fire)
    {
        _animator = animator;
        _transform = transform;
        _allStates = new List<PlayerState>()
        {
            new DefaultState(this),
            new StayState(_animator, this),
            new RunState(_animator, _transform, this),
            new AimState(_animator, _transform, this, fire),
            new BraveState(this, _animator),
            new BreakState(_animator)
            //new IdleState(_animator, this),
            //new RunningState(_animator, _transform, this),
            //new AimingState(_animator, _transform, this, fire),
        };
        _currentState = FindState<DefaultState>();
        _currentState.Enter();
    }

    public void TryUpdate()
    {
            _currentState.Update();
    }

    public PlayerState FindState<T>() => _allStates.Find(x => x is T);

    public void TrySwitchState<T>()
    {
        PlayerState nextState = FindState<T>();
        if (nextState != null)
        {
            SwitchState(nextState);
            nextState.Enter();
        }
    }


    public void SetMoveVector(Vector2 inputVector) => _currentState.SetMoveVector(inputVector);

    public void Stop() => Enabled = true;

    public void Start() => Enabled = false;

    private void SwitchState(PlayerState state)
    {
        _currentState.ExitStates();
        _currentState = state;
        _currentState.Enter();
    }


}