using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PITask.Input
{
    public interface IPlayerInputHandler
    {
        event Action<Vector2> Move;
        event Action Fire;

        void BlockInput();
        void EnableInput();
    }
}

