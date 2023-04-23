using System;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public event Action<PlayerState> StateChanged;
        
        private List<PlayerState> _allStates;
        private PlayerState _currentState;

        public void Init(PlayerView view)
        {
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
        }

        public PlayerState GetStartState()
        {
            _currentState = GetRootState<DefaultState>();
            _currentState.Enter();
            return _currentState;
        }

        public void SetRootState<T>()
        {
            PlayerState nextState = GetRootState<T>();
            SwitchState(nextState);
        }
        private void Update()
            => _currentState.Update();

        public PlayerState GetRootState<T>() 
            => _allStates.Find(x => x is T) ?? throw new InvalidOperationException();

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

        private void SwitchState(PlayerState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
            StateChanged.Invoke(_currentState);
        }
    }
}