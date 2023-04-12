﻿namespace EnemySystem
{
    public interface IState
    {
        public void Update();
        public void FixedUpdate();
        public void OnEnter();
        public void OnExit();
    }
}