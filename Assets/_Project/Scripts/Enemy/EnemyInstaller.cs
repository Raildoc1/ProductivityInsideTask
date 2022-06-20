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
        [SerializeField] private CharacterDetector _weapon;

        private CharacterHealth _characterHealth;
        private CharacterAttack _characterAttack;
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

            _characterAttack = new CharacterAttack(_stats);

            _characterHealth.Init(_stats);
            _characterDetector.Init(_stats.GetStat("ChaseDistance"));
            _weapon.Init(_stats.GetStat("AttackDistance"));
            _enemyAI.Init(_characterDetector, _stats);

            _characterHealth.Die += Die;
            _weapon.DetectCharacter += Attack;
        }

        public void Deinit()
        {
            _enemyAI.Deinit();

            _characterHealth.Die -= Die;
            _weapon.DetectCharacter -= Attack;
        }

        private void Die()
        {
            //TODO: return to pool
            Deinit();
            Destroy(gameObject);
        }

        private void Attack(CharacterHealth target)
        {
            _characterAttack.DealDamageTo(target);
        }
    }
}