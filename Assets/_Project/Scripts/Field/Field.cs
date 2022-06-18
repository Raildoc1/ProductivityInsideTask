using UnityEngine;

namespace PITask
{
    public class Field : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _fieldWidth = 3;
        [SerializeField] [Min(0)] private int _fieldHeight = 6;

        [SerializeField] private Transform _floor;

        private void OnDrawGizmos()
        {
            var color = Gizmos.color;
            Gizmos.color = Color.yellow;

            for (int i = 0; i < _fieldWidth + 1; i++)
            {
                Gizmos.DrawLine(new Vector3(i, 0.1f, 0.0f), new Vector3(i, 0.1f, _fieldHeight));
            }

            for (int i = 0; i < _fieldHeight + 1; i++)
            {
                Gizmos.DrawLine(new Vector3(0.0f, 0.1f, i), new Vector3(_fieldWidth, 0.1f, i));
            }

            Gizmos.color = color;
        }

        public void ApplySettings()
        {
            _floor.localScale = new Vector3(_fieldWidth + 1, 0.5f, _fieldHeight + 1);
        }
    }
}