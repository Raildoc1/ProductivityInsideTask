using PITask.Character;
using PITask.Stats;
using UnityEngine;
using UnityEngine.AI;

namespace PITask.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private CharacterHealth _player;
        private CharacterDetector _detector;
        private float _attackDistacne;
        private bool _attacked = false;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!_player)
            {
                return;
            }

            var playerPosition = _player.transform.position;
            var position = transform.position;
            var distance = Vector3.Distance(position, playerPosition);

            _agent.SetDestination(playerPosition);

            if (!_attacked && (distance < _attackDistacne))
            {
                _attacked = true;
            }
            else if (_attacked && (distance < _attackDistacne * 2.0f))
            {
                var direction = (position - playerPosition).normalized;
                _agent.SetDestination(position + direction);
            }
            else
            {
                _attacked = false;
                _agent.SetDestination(playerPosition);
            }
        }

        public void Init(CharacterDetector detector, StatsDictionary stats)
        {
            _agent.speed = stats.GetStat("MaxSpeed");
            _attackDistacne = stats.GetStat("AttackDistance");
            _detector = detector;

            _detector.DetectCharacter += OnDetectCharacter;
            _detector.LoseCharacter += OnLoseCharacter;
        }

        public void Deinit()
        {
            _detector.DetectCharacter -= OnDetectCharacter;
            _detector.LoseCharacter -= OnLoseCharacter;
        }

        private void OnDetectCharacter(CharacterHealth health)
        {
            _player = health;
            _agent.isStopped = false;
        }

        private void OnLoseCharacter(CharacterHealth health)
        {
            if (health.Equals(_player))
            {
                _agent.isStopped = true;
                _player = null;
            }
        }
    }
}