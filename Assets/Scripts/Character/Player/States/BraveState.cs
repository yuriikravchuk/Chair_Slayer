using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveState : PlayerState
{
    private readonly Animator _animator;
    public BraveState(PlayerStateMachine stateMachine, Animator animator)
    {
        StateMachine = stateMachine;
        _animator = animator;
    }
    public override void Enter()
    {
        Debug.Log("Brave");
        _animator.SetTrigger("brave");
        InitSubState();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    protected override void InitSubState()
    {
        //SetSubState<BraveState>();
    }

    protected override void OnUpdate() { }

    protected override void TryTransit()
    {
        if (StateMachine.Brave == false)
            StateMachine.TrySwitchState<DefaultState>();
    }

    protected override void TryFire() { }

    protected override void TryMove() { }

    protected override void TryRotate() { }
}
