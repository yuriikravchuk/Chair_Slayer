using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public readonly bool isRoot;
    protected PlayerStateMachine StateMachine;
    protected Vector3 MoveVector;
    protected PlayerState SuperState;
    protected PlayerState SubState;

    public void Update()
    {
        TryTransit();
        OnUpdate();
        TryUpdateSubstate();
    }

    public void SetMoveVector(Vector2 moveVector)
    {
        MoveVector = new Vector3(moveVector.x, 0, moveVector.y);
        MoveVector.Normalize();
        if(SubState != null)
            SubState.SetMoveVector(moveVector);
    }

    public void ExitStates()
    {
        Exit();
        if (SubState != null)
            SubState.Exit();
    }

    public void SetSubState<T>()
    {
        SubState = StateMachine.FindState<T>();
        SubState.SetSuperState(this);
        SubState.Enter();
    }

    public abstract void Enter();
    public abstract void Exit();

    protected abstract void OnUpdate();
    protected abstract void TryMove();
    protected abstract void TryRotate();
    protected abstract void TryFire();
    protected abstract void TryTransit();
    protected abstract void InitSubState();
    private void TryUpdateSubstate()
    {
        if (SubState != null)
            SubState.Update();
    }
    private void SetSuperState(PlayerState superState) => SuperState = superState;
}