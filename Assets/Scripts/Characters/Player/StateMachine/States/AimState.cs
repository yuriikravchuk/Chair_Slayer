using UnityEngine;

namespace playerStateMachine
{
    public class AimState : PlayerState
    {
        public AimState(PlayerView player)
        {
            View = player;
        }

        public override bool CanFire() => true;

        protected override void OnUpdate()
        {
            TryMove();
            TryRotate();
        }
        protected override void OnEnter() => View.Aim();

        protected override void OnExit() => View.StopAim();

        protected override void TryRotate() => View.LookAtClosestEnemy();

        protected override void TryMove() => View.SetMoveVector(MoveVector);

        protected override void TryTransit()
        {
            if (SuperState.Aiming == false)
            {
                if (SuperState.Moving)
                    SuperState.SetSubState<RunState>();
                else
                    SuperState.SetSubState<StayState>();

                OnExit();
            }
        }
    }

}
