namespace PITask.Character.Health
{
    public class SimpleDamage : IDamageStrategy
    {
        public float ModifyDamage(float raw) => raw;
    }
}