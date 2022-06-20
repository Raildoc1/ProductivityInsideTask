using PITask.Stats;

namespace PITask.Character
{
    public class CharacterAttack
    {
        private float _attackStrength;

        public CharacterAttack(StatsDictionary stats)
        {
            _attackStrength = stats.GetStat("Damage");
        }

        public void DealDamageTo(CharacterHealth target)
        {
            target.ApplyDamage(_attackStrength);
        }
    }
}