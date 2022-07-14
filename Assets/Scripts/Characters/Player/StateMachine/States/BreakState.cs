using UnityEngine;
namespace playerStateMachine
{
    public class BreakState : PlayerState
    {
        public BreakState(PlayerView view)
            => View = view;

        protected override void OnEnter()
            => View.SetBreak();

        public override bool IsDamagable() 
            => false;
    }
}