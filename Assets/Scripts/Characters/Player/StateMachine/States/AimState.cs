namespace player
{
    public class AimState : PlayerState
    {
        public AimState(PlayerView player)
        {
            View = player;
        }

        protected override void OnUpdate()
        {
            TryMove();
            TryRotate();
            TryFire();
        }
        protected override void OnEnter() => View.Aim();

        protected override void OnExit() => View.StopAim();

        protected override void TryFire() => View.TryFire();

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
