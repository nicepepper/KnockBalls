using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        //[SerializeField] private EnemyFactory _enemyFactory;
        
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _spawnPoint;
        [SerializeField, Range(0f, 20f)] private float _spawnRadius = 1f;
        [SerializeField] private float _spawnDelay = 5f;
        [SerializeField] private int _spawnCounter = 10;

        private void Start()
        {
            
        }

        private List<GameObject> _enamyAIs = new List<GameObject>();
        
        private IEnumerator RoundSpawner()
        { 
           while (_spawnCounter > 0)
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
            Gizmos.DrawWireSphere(_spawnPoint.transform.position, _spawnRadius);
        }
    }
}
