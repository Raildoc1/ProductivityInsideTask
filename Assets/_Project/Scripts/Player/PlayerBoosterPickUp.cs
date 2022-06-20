using PITask.Character.Health;
using UnityEngine;

namespace PITask.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerBoosterPickUp : MonoBehaviour
    {
        private CharacterHealth _health;

        public void Init(CharacterHealth health)
        {
            _health = health;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Enter {other.gameObject.name}");
            if(other.TryGetComponent<ImmortalityBooster>(out var booster))
            {
                booster.ApplyBooster(_health);
            }
        }
    }
}