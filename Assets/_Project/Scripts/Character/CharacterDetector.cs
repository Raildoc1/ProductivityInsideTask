using System;
using UnityEngine;

namespace PITask.Character
{
    [RequireComponent(typeof(SphereCollider))]
    public class CharacterDetector : MonoBehaviour
    {
        private SphereCollider _sphereCollider;

        public event Action<CharacterHealth> DetectCharacter;
        public event Action<CharacterHealth> LoseCharacter;

        private void Awake()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }

        public void Init(float detectDistance)
        {
            _sphereCollider.radius = detectDistance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<CharacterHealth>(out var health))
            {
                DetectCharacter?.Invoke(health);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.TryGetComponent<CharacterHealth>(out var health))
            {
                LoseCharacter?.Invoke(health);
            }
        }
    }
}