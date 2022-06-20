namespace PITask.Character.Health
{
    public class CriticalDamage : IDamageStrategy
    {
        private int _hitsAmount;
        private int _hitsToCritical;

        public CriticalDamage(int hitsToCritical)
        {
            _hitsAmount = 0;
            _hitsToCritical = hitsToCritical;
        }

        public float ModifyDamage(float raw)
        {
            _hitsAmount++;
            var critical = _hitsAmount == _hitsToCritical;
            _hitsAmount %= _hitsToCritical;
            return critical ? raw * 2.0f : raw;
        }
    }
}