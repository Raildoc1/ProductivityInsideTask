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

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(!_player)
            {
                return;
            }

            _agent.isStopped = false;
            _agent.SetDestination(_player.transform.position);
        }

        public void Init(CharacterDetector detector, StatsDictionary stats)
        {
            _agent.speed = stats.GetStat("MaxSpeed");
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
        }

        private void OnLoseCharacter(CharacterHealth health)
        {
            if(health.Equals(_player))
            {
                _agent.isStopped = true;
                _player = null;
            }
        }
    }
}