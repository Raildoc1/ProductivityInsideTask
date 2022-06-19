using PITask.Enemies;
using PITask.Input;
using PITask.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PITask.Core
{
    public class GameStarter : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerInstaller _playerInstaller;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private InputType _inputType;
        [SerializeField] private Transform _initialPlayerPosition;
        [SerializeField] private EnemyInstaller _enemyInstaller;

        private KeyboardPlayerInput _inputHandler;

        private void Start()
        {
            switch (_inputType)
            {
                case InputType.KeyboardAndMouse:
                    _playerInput.SwitchCurrentControlScheme(Keyboard.current, Mouse.current);
                    break;
                case InputType.Joystick:
                    _playerInput.SwitchCurrentControlScheme(Joystick.current);
                    break;
            }
            _inputHandler = new KeyboardPlayerInput();

            _inputHandler.Init(_playerInput);
            _playerInstaller.Init(_initialPlayerPosition, _inputHandler);
            _enemyInstaller.Init();
        }

        private void OnDestroy()
        {
            _playerInstaller.Deinit();
            _inputHandler.Deinit();
            _enemyInstaller.Deinit();
        }
    }

}