using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace playerStateMachine
{
    public class PlayerStateMachine
    {
        private readonly List<PlayerState> _allStates;
        private PlayerState _currentState;
        private readonly PlayerFacade _player;

        public PlayerStateMachine(PlayerView view, PlayerFacade player)
        {
            _player = player;
            _allStates = new List<PlayerState>()
            {
                new DefaultState(new List<PlayerState>
                {
                    new StayState(view),
                    new RunState(view),
                    new AimState(view)
                }),
                new BraveState(view),
                new BreakState(view)
            };

            SetRootState<DefaultState>();
        }

        public void UpdateCurrentState()
            => _currentState.Update();

        public void SetRootState<T>()
        {
            PlayerState nextState = _allStates.First(x => x is T);
            _currentState?.Exit();
            _currentState = nextState;
            _currentState.Enter();
            _player.SetState(_currentState);
        }

        public void SetMoveVector(Vector2 inputVector)
            => _currentState.SetMoveVector(inputVector);

        public void StartAiming()
            => _currentState.Aiming = true;

        public void StopAiming()
            => _currentState.Aiming = false;

        public void StartMoving()
            => _currentState.Moving = true;

        public void StopMoving()
            => _currentState.Moving = false;

        public bool CanFire() 
            => _currentState.CanFire();
    }
}