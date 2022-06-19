using PITask.Character;
using PITask.Stats;
using UnityEngine;

namespace PITask.Enemies
{
    [RequireComponent(typeof(CharacterHealth))]
    [RequireComponent(typeof(EnemyAI))]
    public class EnemyInstaller : MonoBehaviour
    {
        [SerializeField] private StatsDictionary _stats;
        [SerializeField] private CharacterDetector _characterDetector;

        private CharacterHealth _characterHealth;
        private CharacterHealth _player;
        private EnemyAI _enemyAI;

        public void Init(Transform initialPose)
        {
            transform.position = initialPose.position;
            transform.rotation = initialPose.rotation;
            Init();
        }

        public void Init()
        {
            _characterHealth = GetComponent<CharacterHealth>();
            _enemyAI = GetComponent<EnemyAI>();

            _characterHealth.Init(_stats);
            _characterDetector.Init(_stats.GetStat("ChaseDistance"));
            _enemyAI.Init(_characterDetector, _stats);

            _characterHealth.Die += Die;
        }

        public void Deinit()
        {
            _enemyAI.Deinit();

            _characterHealth.Die -= Die;
        }

        private void Die()
        {
            //TODO: return to pool
            Deinit();
            Destroy(gameObject);
        }
    }
}