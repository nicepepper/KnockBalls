using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
   [RequireComponent(typeof(NavMeshAgent))]
   public class EnemyAI : MonoBehaviour
   {
      [SerializeField] private Transform[] _waypoints = new Transform[]{};
      private NavMeshAgent _agent;
      private int _waypointIndex = 0;
      private Vector3 _target;

      private void Start()
      {
         _agent = GetComponent<NavMeshAgent>();
         UpdateDestination();
         
         
      }

      private void Update()
      {
         if (Vector3.Distance(transform.position, _target) < 1)
         {
            IterateWaypointIndex();
            UpdateDestination();
         }
      }

      private void UpdateDestination()
      {
         if (_waypoints.Length != 0)
         {
            _target = _waypoints[_waypointIndex].position;
            _agent.SetDestination(_target);
         }
      }

      private void IterateWaypointIndex()
      {
         if (_waypoints.Length != 0)
         {
            _waypointIndex++;
            if (_waypointIndex == _waypoints.Length)
            {
               _waypointIndex = 0;
            }
         }
      }
   }
}
