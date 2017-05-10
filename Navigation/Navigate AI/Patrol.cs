using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    public Waypoint[] Waypoints;
    private NavMeshAgent _navMeshAgent;
    private float _moveSpeed = 3.5f;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustSpeedOnTurn();
        if (!_navMeshAgent.pathPending
            &&
            _navMeshAgent.remainingDistance
            <=
            _navMeshAgent.stoppingDistance)
        // We arrived, reset the destination
        {
            Debug.Log("Arrived - done navigating, setting new location");

            //generate random number in our desired range
            var index = Random.Range(0, Waypoints.Length);
            //get that random waypoint from the list
            var waypoint = Waypoints[index];

            //go to that waypoints position
            _navMeshAgent.SetDestination(waypoint.transform.position);
        }
    }

    void AdjustSpeedOnTurn()
    {
        float speedMultiplyer = 1.0f - 0.9f * Vector3.Angle(transform.forward, _navMeshAgent.steeringTarget - transform.position) / 180.0f;
        _navMeshAgent.speed = _moveSpeed * speedMultiplyer;
    }





}
