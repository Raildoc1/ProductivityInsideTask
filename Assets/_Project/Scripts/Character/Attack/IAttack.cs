using PITask.Character.Health;

namespace PITask.Character.Attack
{
    public interface IAttack
    {
        void DealDamageTo(CharacterHealth target, float damage);
    }
}
