using PITask.Character;
using UnityEngine;

namespace PITask.Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _speed = 10.0f;
        [SerializeField] [Min(0.0f)] private float _bulletLifeTime = 3.0f;

        private Vector3 _velocity = Vector3.zero;
        private Rigidbody _rigidbody;
        private BulletPool _pool;
        private float _damage;
        private float _timer;

        private Vector3 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                _rigidbody.velocity = _velocity;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(BulletPool pool)
        {
            _pool = pool;
        }

        public void Setup(float damage)
        {
            Velocity = transform.forward * _speed;
            _damage = damage;
            _timer = _bulletLifeTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if(_timer <= 0.0f)
            {
                TryReturnToPool();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<CharacterHealth>(out var health))
            {
                health.ApplyDamage(_damage);
            }
            TryReturnToPool();
        }

        private void TryReturnToPool()
        {
            if (gameObject.activeSelf)
            {
                _pool.Release(this);
            }
        }
    }
}