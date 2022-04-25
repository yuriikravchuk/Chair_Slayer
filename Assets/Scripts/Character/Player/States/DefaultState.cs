using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : PlayerState
{
    public DefaultState(PlayerStateMachine _stateMachine)
    {
        StateMachine = _stateMachine;
    }
    public override void Enter()
    {
        InitSubState();
    }

    public override void Exit() {}

    protected override void InitSubState()
    {
        if (StateMachine.Aiming)
            SetSubState<AimState>();
        else if (StateMachine.Moving)
            SetSubState<RunState>();
        else
            SetSubState<StayState>();
    }

    protected override void OnUpdate()
    {
 
    }

    protected override void TryTransit() 
    {
        if (StateMachine.Brave)
            StateMachine.TrySwitchState<BraveState>();
    }

    protected override void TryFire()
    {
        throw new System.NotImplementedException();
    }
    protected override void TryMove()
    {
        throw new System.NotImplementedException();
    }
    protected override void TryRotate()
    {
        throw new System.NotImplementedException();
    }
}
