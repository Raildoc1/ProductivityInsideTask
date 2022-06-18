using PITask.Character;
using PITask.Input;
using UnityEngine;

namespace PITask.Player
{
    public class PlayerMovementController
    {
        private CharacterMotor _characterMotor;
        private IPlayerInputHandler _inputHandler;

        public void Init(CharacterMotor characterMotor, IPlayerInputHandler inputHandler)
        {
            _characterMotor = characterMotor;
            _inputHandler = inputHandler;

            _inputHandler.Move += SetMovementDirection;
        }

        public void Deinit()
        {
            _inputHandler.Move -= SetMovementDirection;
        }

        private void SetMovementDirection(Vector2 direction)
        {
            _characterMotor.Move(direction);
        }
    }
}