using PITask.Character;
using PITask.Character.Health;
using PITask.Input;
using PITask.Shooting;
using PITask.Stats;
using PITask.UI;
using UnityEngine;

namespace PITask.Player
{
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(CharacterShooter))]
    [RequireComponent(typeof(CharacterHealth))]
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private StatsDictionary _stats;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private PlayerBoosterPickUp _boosterPickup;

        private CharacterMotor _characterMotor;
        private CharacterShooter _characterShooter;
        private CharacterHealth _characterHealth;

        private PlayerMovementController _playerMovementController = new PlayerMovementController();
        private PlayerShootingController _playerShootingController = new PlayerShootingController();

        private WindowsManager _windowsManager;

        public void Init(Transform initialPose, IPlayerInputHandler input, WindowsManager windowsManager)
        {
            _characterMotor = GetComponent<CharacterMotor>();
            _characterShooter = GetComponent<CharacterShooter>();
            _characterHealth = GetComponent<CharacterHealth>();

            _windowsManager = windowsManager;

            _characterHealth.Init(_stats, new SimpleDamage());
            _characterMotor.Init(_stats, initialPose);
            _characterShooter.Init(_bulletPool, _stats);
            _playerMovementController.Init(_characterMotor, input);
            _playerShootingController.Init(_characterShooter, input);
            _boosterPickup.Init(_characterHealth);

            _characterHealth.Die += OnDie;
        }

        public void Deinit()
        {
            _playerMovementController.Deinit();
            _playerShootingController.Deinit();

            _characterHealth.Die -= OnDie;
        }

        private void OnDie()
        {
            _windowsManager.TryShowWindow(WindowType.End);
        }
    }
}

