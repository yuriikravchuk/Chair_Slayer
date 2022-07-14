using System.Collections.Generic;

namespace playerStateMachine
{
    public class DefaultState : PlayerState
    {
        public DefaultState(List<PlayerState> subStates) => SubStates = subStates;

        protected override void InitSubState() 
        {
            Moving = false;
            Aiming = false;
            SetSubState<StayState>();
        }
    }

}