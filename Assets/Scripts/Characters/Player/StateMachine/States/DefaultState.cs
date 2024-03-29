﻿using System.Collections.Generic;

namespace player
{
    public class DefaultState : PlayerState
    {
        public DefaultState(List<PlayerState> subStates) => SubStates = subStates;

        protected override void InitSubState() => SetSubState<StayState>();
    }

}