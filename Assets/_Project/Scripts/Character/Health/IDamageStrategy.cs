namespace PITask.Character.Health
{
    public interface IDamageStrategy
    {
        float ModifyDamage(float raw);
    }
}