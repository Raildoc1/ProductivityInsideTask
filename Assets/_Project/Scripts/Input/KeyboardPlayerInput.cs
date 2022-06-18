using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PITask.Input
{
    public class KeyboardPlayerInput : IPlayerInputHandler
    {
        private const string MoveActionName = "Move";

        private InputAction _moveAction;

        public event Action<Vector2> Move;

        public void Init(PlayerInput input)
        {
            _moveAction = input.currentActionMap.FindAction(MoveActionName);
            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCancelled;
        }

        public void Deinit()
        {
            _moveAction.performed -= OnMovePerformed;
            _moveAction.canceled -= OnMoveCancelled;
        }

        private void OnMovePerformed(InputAction.CallbackContext context) => Move?.Invoke(context.action.ReadValue<Vector2>());
        private void OnMoveCancelled(InputAction.CallbackContext context) => Move?.Invoke(Vector2.zero);
    }
}
