using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PITask.Input
{
    public class KeyboardPlayerInput : IPlayerInputHandler
    {
        private const string MoveActionName = "Move";
        private const string FireActionName = "Fire";

        private InputAction _moveAction;
        private InputAction _fireAction;

        public event Action<Vector2> Move;
        public event Action Fire;

        public void Init(PlayerInput input)
        {
            _moveAction = input.currentActionMap.FindAction(MoveActionName);
            _fireAction = input.currentActionMap.FindAction(FireActionName);


            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCancelled;
            _fireAction.performed += OnFirePerformed;
        }

        public void Deinit()
        {
            _moveAction.performed -= OnMovePerformed;
            _moveAction.canceled -= OnMoveCancelled;
            _fireAction.performed -= OnFirePerformed;
        }

        private void OnMovePerformed(InputAction.CallbackContext context) => Move?.Invoke(context.action.ReadValue<Vector2>());
        private void OnMoveCancelled(InputAction.CallbackContext context) => Move?.Invoke(Vector2.zero);
        private void OnFirePerformed(InputAction.CallbackContext context) => Fire?.Invoke();
    }
}
