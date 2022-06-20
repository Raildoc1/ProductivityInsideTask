using PITask.Character.Health;
using UnityEngine;

namespace PITask.Player
{
    public class ImmortalityBooster : MonoBehaviour
    {
        public void ApplyBooster(CharacterHealth health)
        {
            health.ApplyImmortality();
            Destroy(gameObject);
        }
    }
}
