using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CustomGameEvent;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        //[SerializeField] private EnemyView _view;
        [SerializeField] private List<Vector3> _waypoints = new List<Vector3>();
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        
        private NavMeshAgent _agent;
        private int _waypointIndex = 0;
        private Vector3 _target;
        
        public EnemyFactory OriginFactory { get; set; }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            UpdateDestination();
        }

        public void Initialize(float speed, float health)
        {
            _agent.speed = _speed = speed;
            _health = health;
            //_view.Init(this);
        }

        public void Warp(Vector3 pos)
        {
            _agent.Warp(pos);
        }
        
        public void AddWaypoint(Vector3 pos)
        {
            _waypoints.Add(pos);
        }

        public void TakeDamage(float amount)
        {
            _health -= amount;
        }

        public bool GameUpdate()
        {
            if (_health <= 0f)
            {
                GameEvent.SendEnemyKilled();
                //_view.Die();
                Recycle();
                return false;
            }
            
            if (Vector3.Distance(transform.position, _target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
            return true;
        }

        public void Recycle()
        {
            OriginFactory.Reclaim(this);
        }
        
        private void UpdateDestination()
        {
            if (_waypoints.Count != 0)
            {
                _target = _waypoints[_waypointIndex];
                _agent.SetDestination(_target);
            }
        }

        private void IterateWaypointIndex()
        {
            if (_waypoints.Count != 0)
            {
                _waypointIndex++;
                if (_waypointIndex == _waypoints.Count)
                {
                    _waypointIndex = 0;
                }
            }
        }
        
        
    }
}
