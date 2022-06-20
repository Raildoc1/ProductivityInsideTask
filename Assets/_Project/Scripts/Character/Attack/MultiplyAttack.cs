using PITask.Character.Health;
using PITask.Stats;

namespace PITask.Character.Attack
{
    public class MultiplyAttack : IAttack
    {
        private CharacterAttack _characterAttack;
        private float _multiplier;

        public MultiplyAttack(CharacterAttack characterAttack, StatsDictionary stats)
        {
            _characterAttack = characterAttack;
            _multiplier = stats.GetStat("AttackMultiplier");
        }
        public void DealDamageTo(CharacterHealth target, float damage)
        {
            _characterAttack.DealDamageTo(target, damage * _multiplier);
        }
    }
}
