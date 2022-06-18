using UnityEngine;

namespace PITask.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMotor : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _acceleration = 1.0f;

        private CharacterController _characterController;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _desiredVelocity = Vector3.zero;
        private float _maxSpeed = 5.0f;

        public float MaxSpeed {
            get => _maxSpeed;
            set => _maxSpeed = Mathf.Max(0.0f, value);
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _velocity = Vector3.MoveTowards(_velocity, _desiredVelocity, _acceleration * deltaTime);
            _characterController.Move(_velocity * deltaTime);
        }

        public void Move(Vector2 direction)
        {
            Move(new Vector3(direction.x, 0.0f, direction.y));
        }

        public void Move(Vector3 direction)
        {
            _desiredVelocity = direction.normalized * _maxSpeed;
        }
    }
}
