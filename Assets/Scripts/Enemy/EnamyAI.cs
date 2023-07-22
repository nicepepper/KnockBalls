using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnamyAI : MonoBehaviour
{
   [SerializeField] private Transform[] _waypoints;
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
      _target = _waypoints[_waypointIndex].position;
      _agent.SetDestination(_target);
   }

   private void IterateWaypointIndex()
   {
      _waypointIndex++;
      if (_waypointIndex == _waypoints.Length)
      {
         _waypointIndex = 0;
      }
   }
}
