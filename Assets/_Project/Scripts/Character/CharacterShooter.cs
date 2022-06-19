using PITask.Shooting;
using PITask.Stats;
using UnityEngine;

namespace PITask.Character
{
    public class CharacterShooter : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private float _timer = 0.0f;
        private float _shootDelay = 0.5f;
        private float _damage = 0.0f;
        private BulletPool _bulletsPool;

        public void Init(BulletPool bulletsPool, StatsDictionary stats)
        {
            _bulletsPool = bulletsPool;
            _shootDelay = stats.GetStat("ShootDelay");
            _damage = stats.GetStat("Damage");
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
        }

        public void Shoot()
        {
            if (_timer > 0.0f)
            {
                return;
            }
            _bulletsPool.SpawnBullet(_bulletSpawnPoint, _damage);
            _timer = _shootDelay;
        }
    }
}