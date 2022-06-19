using PITask.Stats;
using System;
using UnityEngine;

namespace PITask.Character
{
    public class CharacterHealth : MonoBehaviour
    {
        private float _currentHealth;

        public bool Dead => _currentHealth <= 0.0f;

        public Action Die;

        public void Init(StatsDictionary stats)
        {
            _currentHealth = stats.GetStat("MaxHealth");
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

            _currentHealth -= value;

            if(Dead)
            {
                Die?.Invoke();
            }
        }
    }
}