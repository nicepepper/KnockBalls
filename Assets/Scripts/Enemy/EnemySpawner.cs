using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _spawnDelay = 5.0f;
        [SerializeField] private float _spawnRadius = 0.1f;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _spawnCounter = 10;

        private void Update()
        {
            StartCoroutine("RoundSpawner");
        }

        private List<GameObject> _enamyAIs =new List<GameObject>();
        
        private IEnumerator RoundSpawner()
        {
            if (_spawnCounter > 0)
            {
                _spawnCounter--;
                Vector3 point = GetRandomPointInСircleXZ(_spawnPoint.transform.position, _spawnRadius);
                _enamyAIs.Add(Instantiate(_enemyPrefab, point, Quaternion.identity));
                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        private Vector3 GetRandomPointInСircleXZ(Vector3 center, float radius)
        {
            Vector2 point = new Vector2();
            point = Random.insideUnitCircle;
            return new Vector3(center.x + point.x * radius, center.y, center.z + point.y * radius);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_spawnPoint.position, _spawnRadius);
        }
    }
}
