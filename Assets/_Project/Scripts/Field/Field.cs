using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

namespace PITask.Core
{
    public class Field : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _fieldWidth = 3;
        [SerializeField] [Min(0)] private int _fieldHeight = 6;

        [SerializeField] private Transform _floor;
        [SerializeField] private List<Transform> _walls;
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private int _wallsAmount;
        [SerializeField] private Transform _wallsRoot;
        [SerializeField] private Transform _playerSpawnPosition;

        private List<Vector2Int> _takenPositions;

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

            _walls[0].localScale = new Vector3(_fieldWidth + 1, 1.0f, 0.5f);
            _walls[0].position = new Vector3(-0.5f, 0.0f, _fieldHeight);

            _walls[1].localScale = new Vector3(_fieldWidth + 1, 1.0f, 0.5f);
            _walls[1].position = new Vector3(-0.5f, 0.0f, -0.5f);

            _walls[2].localScale = new Vector3(0.5f, 1.0f, _fieldHeight + 1);
            _walls[2].position = new Vector3(_fieldWidth, 0.0f, -0.5f);

            _walls[3].localScale = new Vector3(0.5f, 1.0f, _fieldHeight + 1);
            _walls[3].position = new Vector3(-0.5f, 0.0f, -0.5f);

            GenerateObstacles();
        }

        public void GenerateObstacles()
        {
            var childCount = _wallsRoot.childCount;
            for (var i = childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(_wallsRoot.GetChild(i).gameObject);
            }

            _takenPositions.Clear();

            for (var i = 0; i < _wallsAmount; i++)
            {
                var obstacle = Instantiate(_wallPrefab, _wallsRoot);
                var x = Random.Range(0, _fieldWidth);
                var y = Random.Range(0, _fieldHeight);
                obstacle.transform.position = new Vector3(x, 0.0f, y);
                _takenPositions.Add(new Vector2Int(x, y));
            }

            Vector2Int playerSpawnPosition;

            do
            {
                var x = Random.Range(0, _fieldWidth);
                var y = Random.Range(0, _fieldHeight);
                playerSpawnPosition = new Vector2Int(x, y);
            } while (_takenPositions.Contains(playerSpawnPosition));

            _playerSpawnPosition.position = new Vector3(playerSpawnPosition.x + 0.5f, 0.0f, playerSpawnPosition.y + 0.5f);
            NavMeshBuilder.BuildNavMesh();
        }
    }
}