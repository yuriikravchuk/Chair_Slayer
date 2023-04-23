using System;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public abstract class PlayerState
    {
        public bool Moving;
        public bool Aiming;

        protected PlayerView View;
        protected Vector3 MoveVector;
        protected PlayerState SubState;
        protected PlayerState SuperState;
        protected List<PlayerState> SubStates;

        public void Enter()
        {
            OnEnter();
            if(SubStates?.Count > 0)
            {
                foreach (var subState in SubStates)
                    subState.SetSuperState(this);

                InitSubState();
            }
        }

        public void Update()
        {
            TryTransit();
            OnUpdate();
            SubState?.Update();
        } 

        public void Exit()
        {
            OnExit();
            SubState?.Exit();
        }

        public void SetSubState<T>()
        {
            SubState = SubStates.Find(x => x is T) ?? throw new InvalidOperationException();
            SubState.SetSuperState(this);
            SubState.OnEnter();
        }

        public void SetSuperState(PlayerState superState) => SuperState = superState;
        public void SetMoveVector(Vector2 moveVector)
        {
            MoveVector = new Vector3(moveVector.x, 0, moveVector.y);
            MoveVector.Normalize();
            if (SubState != null)
                SubState.SetMoveVector(moveVector);
        }



        public virtual bool IsDamageable()
            => SubState != null ? SubState.IsDamageable() : true;

        protected virtual void OnExit() { }
        protected virtual void OnEnter() { }
        protected virtual void OnUpdate() { }
        protected virtual void TryMove() { }
        protected virtual void TryRotate() { }
        protected virtual void TryFire() { }
        protected virtual void TryTransit() { }
        protected virtual void InitSubState() { }
    }
}
