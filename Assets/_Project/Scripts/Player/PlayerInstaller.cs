using PITask.Character;
using PITask.Input;
using PITask.Shooting;
using PITask.Stats;
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

        private IPlayerInputHandler _input;

        private CharacterMotor _characterMotor;
        private CharacterShooter _characterShooter;
        private CharacterHealth _characterHealth;

        private PlayerMovementController _playerMovementController = new PlayerMovementController();
        private PlayerShootingController _playerShootingController = new PlayerShootingController();

        public void Init(Transform initialPose, IPlayerInputHandler input)
        {
            _characterMotor = GetComponent<CharacterMotor>();
            _characterShooter = GetComponent<CharacterShooter>();
            _characterHealth = GetComponent<CharacterHealth>();

            _input = input;

            transform.position = initialPose.position;
            transform.rotation = initialPose.rotation;

            _characterHealth.Init(_stats);
            _characterMotor.Init(_stats);
            _characterShooter.Init(_bulletPool, _stats);
            _playerMovementController.Init(_characterMotor, _input);
            _playerShootingController.Init(_characterShooter, _input);
        }

        public void Deinit()
        {
            _playerMovementController.Deinit();
            _playerShootingController.Deinit();
        }
    }
}

