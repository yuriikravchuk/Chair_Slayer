using System;
using System.Collections.Generic;
using UnityEngine;
namespace playerStateMachine
{
    public class PlayerMovementStateMachine
    {
        private readonly List<PlayerState> _allStates;
        private PlayerState _currentState;

        public PlayerMovementStateMachine(PlayerView player)
        {
            _allStates = new List<PlayerState>()
            {
                new DefaultState(new List<PlayerState>
                {
                    new StayState(player),
                    new RunState(player),
                    new AimState(player)
                }),
                new BraveState(player),
                new BreakState(player)
            };

            SetRootState<DefaultState>();
        }

        public void UpdateCurrentState()
            => _currentState.Update();

        public void SetRootState<T>()
        {
            PlayerState nextState = _allStates.Find(x => x is T) ?? throw new InvalidOperationException();
            SwitchState(nextState);
        }

        public void SetMoveVector(Vector2 inputVector)
            => _currentState.SetMoveVector(inputVector);

        private void SwitchState(PlayerState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

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