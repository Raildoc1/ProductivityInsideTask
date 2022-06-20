using System;
using UnityEngine;

namespace PITask.Input
{
    public interface IPlayerInputHandler
    {
        event Action<Vector2> Move;
        event Action Fire;
    }
}

