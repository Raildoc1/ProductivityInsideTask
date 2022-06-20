using PITask.Character.Health;

namespace PITask.Character.Attack
{
    public class CharacterAttack : IAttack
    {
        public void DealDamageTo(CharacterHealth target, float damage)
        {
            target.ApplyDamage(damage);
        }
    }
}