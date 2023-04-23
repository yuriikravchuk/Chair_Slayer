namespace player
{
    public class BreakState : PlayerState
    {
        public BreakState(PlayerView view)
            => View = view;

        protected override void OnEnter()
            => View.SetBreak();
    }
}