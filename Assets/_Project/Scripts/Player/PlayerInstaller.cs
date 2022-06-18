using PITask.Character;
using PITask.Input;
using UnityEngine;

namespace PITask.Player
{
    [RequireComponent(typeof(CharacterMotor))]
    public class PlayerInstaller : MonoBehaviour
    {
        private CharacterMotor _characterMotor;
        private IPlayerInputHandler _input;
        private PlayerMovementController _playerMovementController = new PlayerMovementController();

        public void Init(Transform initialPose, IPlayerInputHandler input)
        {
            _characterMotor = GetComponent<CharacterMotor>();
            _input = input;

            transform.position = initialPose.position;
            transform.rotation = initialPose.rotation;

            _playerMovementController.Init(_characterMotor, _input);
        }

        public void Deinit()
        {
            _playerMovementController.Deinit();
        }
    }
}
