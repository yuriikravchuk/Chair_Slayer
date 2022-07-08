using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerStateMachine
{
    public class RunState : PlayerState
    {
        public RunState(PlayerView view) => View = view;

        protected override void OnUpdate() => TryRotate();

        protected override void OnEnter() => View.Move();

        protected override void TryRotate() => View.SetRotation(MoveVector);

        protected override void TryTransit()
        {
            if (SuperState.Aiming)
                SuperState.SetSubState<AimState>();
            else if (SuperState.Moving == false)
                SuperState.SetSubState<StayState>();
        }
    }

}
