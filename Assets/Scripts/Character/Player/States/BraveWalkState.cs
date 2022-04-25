using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveWalkState : PlayerState
{
    public override void Enter()
    {

    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnUpdate() { }
    protected override void InitSubState() { }

    protected override void TryFire() { }
    protected override void TryMove() { }
    protected override void TryRotate() { }

    protected override void TryTransit() { }
}
