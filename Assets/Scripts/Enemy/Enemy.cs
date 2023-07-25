using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private float _health;
        private float _speed;
        public EnemyFactory OriginFactory { get; set; }

        public void Initialize(float speed, float health)
        {
            _speed = speed;
            _health = health;
        }
        
        public void SpawnOn(Vector3 pos)
        {
            transform.position = pos;
        }

        public bool GameUpdate()
        {
            return true;
        }
    }
}
