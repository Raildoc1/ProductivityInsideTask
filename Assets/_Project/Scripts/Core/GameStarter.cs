using PITask.Enemies;
using PITask.Input;
using PITask.Player;
using PITask.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PITask.Core
{
    public class GameStarter : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerInstaller _playerInstaller;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Transform _initialPlayerPosition;

        [Header("Enemies")]
        [SerializeField] private List<EnemyInstaller> _enemies;

        [Header("UI")]
        [SerializeField] private WindowsManager _windowsManager;

        private KeyboardPlayerInput _inputHandler;

        private void Awake()
        {
            _inputHandler = new KeyboardPlayerInput(); // TODO: implement other input types

            _inputHandler.Init(_playerInput);
            _playerInstaller.Init(_initialPlayerPosition, _inputHandler, _windowsManager);

            _windowsManager.WindowShown += OnWindowShown;
            _windowsManager.WindowHidden += OnWindowHidden;

            foreach (var enemy in _enemies)
            {
                enemy.Init();
            }
        }

        private void OnDestroy()
        {
            _playerInstaller.Deinit();
            _inputHandler.Deinit();

            _windowsManager.WindowShown -= OnWindowShown;
            _windowsManager.WindowHidden -= OnWindowHidden;

            foreach (var enemy in _enemies)
            {
                enemy.Deinit();
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if(!focus)
            {
                _windowsManager.TryShowWindow(WindowType.Pause);
            }
        }

        private void OnWindowShown(WindowType _) => _inputHandler.BlockInput();
        private void OnWindowHidden(WindowType _) => _inputHandler.EnableInput();
    }

}