using UnityEngine;
namespace playerStateMachine
{
    public class StayState : PlayerState
    {
        public StayState(PlayerView player) => View = player;

        protected override void OnEnter() => View.Stop();

        protected override void TryTransit()
        {
            if (SuperState.Aiming)
                SuperState.SetSubState<AimState>();
            else if (SuperState.Moving)
                SuperState.SetSubState<RunState>();
        }
    }

}
