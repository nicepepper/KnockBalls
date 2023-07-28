using System;
using System.Collections;
using System.Collections.Generic;
using CustomGameEvent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        
        [SerializeField] private int _numberWaypoints = 3;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField, Range(0f, 20f)] private float _spawnRadius = 1f;
        [SerializeField] private float _spawnDelay = 5f;
        [SerializeField] private int _spawnCounter = 10;
        [SerializeField] private bool _isEndlessSpawn = false;
        private Coroutine _coroutineHandle;

        public void SpawnEnemy(EnemyCollection enemyCollection)
        {
            _coroutineHandle = StartCoroutine(RoundSpawner(enemyCollection));
        }

        public void StopSpawnEnemy()
        {
            StopCoroutine(_coroutineHandle);
        }

        private IEnumerator RoundSpawner(EnemyCollection enemyCollection)
        { 
           while (_spawnCounter > 0 || _isEndlessSpawn)
           {
               if (!_isEndlessSpawn)
               {
                   _spawnCounter--;
               }
               Vector3 point = GetRandomPointInСircleXZ(_spawnPoint.position, _spawnRadius);
               Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, 2));
               enemyCollection.Add(enemy);
               GameEvent.SendEnemyCreated(enemyCollection.Count());
               enemy.Warp(point);
               SetWaypoints(enemy);
               
               yield return new WaitForSeconds(_spawnDelay);
               yield return new WaitForFixedUpdate();
           }
        }

        private void SetWaypoints(Enemy enemy)
        {
            if (_numberWaypoints > 0)
            {
                for (int i = 0; i < _numberWaypoints; i++)
                {
                    enemy.AddWaypoint(GetRandomPointInСircleXZ(_spawnPoint.position, _spawnRadius));
                }
            }
        }
        
        private Vector3 GetRandomPointInСircleXZ(Vector3 center, float radius)
        {
            Vector2 point = new Vector2();
            point = Random.insideUnitCircle;
            return new Vector3(center.x + point.x * radius, center.y, center.z + point.y * radius);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_spawnPoint.position, _spawnRadius);
        }
    }
}
