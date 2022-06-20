using PITask.Stats;
using System;
using UnityEngine;

namespace PITask.Character.Health
{
    public class CharacterHealth : MonoBehaviour
    {
        private IDamageStrategy _damageStrategy;
        private float _currentHealth;

        public bool Dead => _currentHealth <= 0.0f;

        public Action Die;

        public void Init(StatsDictionary stats, IDamageStrategy damageStrategy)
        {
            _currentHealth = stats.GetStat("MaxHealth");
            _damageStrategy = damageStrategy;
        }

        public void ApplyDamage(float value)
        {
            if(Dead)
            {
                return;
            }

            if(value < 0.0f)
            {
                throw new ArgumentOutOfRangeException("Damage cannot be negative!");
            }

            _currentHealth -= _damageStrategy.ModifyDamage(value);

            if(Dead)
            {
                Die?.Invoke();
            }
        }
    }
}