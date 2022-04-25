using UnityEngine;

public class BreakState : PlayerState
{
    private Animator _animator;
    public BreakState(Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetTrigger("brave_1");
    }

    public override void Exit() { }

    protected override void TryFire() { }

    protected override void TryMove() { }

    protected override void TryRotate() { }

    protected override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected override void TryTransit()
    {
        throw new System.NotImplementedException();
    }

    protected override void InitSubState() { }
}
