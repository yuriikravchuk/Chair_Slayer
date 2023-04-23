
namespace player
{
    public class PlayerStateMediator
    {
        public PlayerStateMediator(Player model, PlayerStateMachine stateMachine)
        {
            stateMachine.StateChanged += model.SetState;
        }
    }
}

