using UnityEngine;

public class AimState : PlayerState
{
    private readonly Transform _transform;
    private readonly Animator _animator;
    private readonly float SpeedRotate = 1;
    private readonly PlayerFire _fire;
    public AimState(Animator animator, Transform transform, PlayerStateMachine stateMachine, PlayerFire fire)
    {
        _transform = transform;
        _animator = animator;
        StateMachine = stateMachine;
        _fire = fire;
    }
    public override void Enter() 
    {
        _animator.SetBool("aiming", true);
    }

    public override void Exit() => _animator.SetBool("aiming", false);

    protected override void OnUpdate()
    {
        TryMove();
        TryRotate();
        TryFire();
    }

    protected override void TryRotate()
    {
        Vector3 targetPosition = FindClosestEnemyPosition(_transform.position);
        Vector3 rotateVector = new Vector3(targetPosition.x - _transform.position.x, 0, targetPosition.z - _transform.position.z);
        Vector3 direction = Vector3.RotateTowards(_transform.forward, rotateVector, SpeedRotate, 0);
        _transform.rotation = Quaternion.LookRotation(direction);
    }

    protected override void TryMove()
    {
        Vector3 localMove = _transform.InverseTransformDirection(MoveVector);
        _animator.SetFloat("Forward", localMove.z, 0.1f, Time.deltaTime);
        _animator.SetFloat("Turn", localMove.x, 0.1f, Time.deltaTime);
    }

    protected override void TryTransit()
    {
        if (StateMachine.Aiming == false)
        {
            if (StateMachine.Moving)
                SuperState.SetSubState<RunState>();
            else
                SuperState.SetSubState<StayState>();

            Exit();
        }
    }

    protected override void TryFire() => _fire.TryFire();

    private Vector3 FindClosestEnemyPosition(Vector3 position) =>
        Singleton<EnemiesManager>.instance.FindClosest(position);

    protected override void InitSubState() { }
}
