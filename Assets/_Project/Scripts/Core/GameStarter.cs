using PITask.Enemies;
using PITask.Input;
using PITask.Player;
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

        private KeyboardPlayerInput _inputHandler;

        private void Start()
        {
            _inputHandler = new KeyboardPlayerInput(); // TODO: implement other input types

            _inputHandler.Init(_playerInput);
            _playerInstaller.Init(_initialPlayerPosition, _inputHandler);
            foreach (var enemy in _enemies)
            {
                enemy.Init();
            }
        }

        private void OnDestroy()
        {
            _playerInstaller.Deinit();
            _inputHandler.Deinit();
            foreach (var enemy in _enemies)
            {
                enemy.Deinit();
            }
        }
    }

}