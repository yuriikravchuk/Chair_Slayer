using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{
    private readonly Animator _animator;
    private readonly Transform _transform;
    private readonly float SpeedRotate = 1;
    public RunState(Animator animator, Transform transform, PlayerStateMachine stateMachine)
    {
        _transform = transform;
        _animator = animator;
        StateMachine = stateMachine;
    }
    public override void Enter() => _animator.SetBool("move", true);
    public override void Exit() { }
    protected override void OnUpdate()
    {
        TryRotate();
    }
    protected override void TryRotate()
    {
        Vector3 direction = Vector3.RotateTowards(_transform.forward, MoveVector, SpeedRotate, 0);
        _transform.rotation = Quaternion.LookRotation(direction);
    }

    protected override void TryMove() { }
    protected override void TryTransit()
    {
        if (StateMachine.Aiming)
            SuperState.SetSubState<AimState>();
        else if(StateMachine.Moving == false)
            SuperState.SetSubState<StayState>();
    }

    protected override void TryFire() { }

    protected override void InitSubState()
    {
        throw new System.NotImplementedException();
    }
}
