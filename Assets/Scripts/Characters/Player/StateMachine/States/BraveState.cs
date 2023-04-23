using UnityEngine;
namespace player
{
    public class BraveState : PlayerState
    {
        public BraveState(PlayerView view) => View = view;

        protected override void OnEnter()
        {
            View.SetBrave();
            View.SetMass(100);
        }

        protected override void OnUpdate() => TryRotate();

        protected override void OnExit() => View.SetMass(1);

        protected override void TryRotate() => View.SetRotation(MoveVector);
    }

}