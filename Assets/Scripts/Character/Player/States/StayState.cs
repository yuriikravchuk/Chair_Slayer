using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayState : PlayerState
{
    private readonly Animator _animator;
    public StayState(Animator animator, PlayerStateMachine stateMachine)
    {
        _animator = animator;
        StateMachine = stateMachine;
    }

    public override void Enter()
    {
        _animator.SetBool("move", false);
    }

    public override void Exit() { }

    protected override void TryTransit()
    {
        if (StateMachine.Aiming)
            SuperState.SetSubState<AimState>();
        else if (StateMachine.Moving)
            SuperState.SetSubState<RunState>();
    }
    protected override void OnUpdate() { }
    protected override void InitSubState() { }

    protected override void TryFire() { }
    protected override void TryMove() { }
    protected override void TryRotate() { }

}
