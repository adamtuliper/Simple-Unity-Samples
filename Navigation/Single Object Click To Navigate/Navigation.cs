using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            var mousePosition = Input.mousePosition;
            Debug.Log(mousePosition);

            var ray = Camera.main.ScreenPointToRay(mousePosition);
            Debug.Log("Direction:" + ray.direction);

            RaycastHit hit;

            if (Terrain.activeTerrain.GetComponent<Collider>().Raycast(ray,
            out hit, 2000f))
            {
                var destination = hit.point;
                _navMeshAgent.SetDestination(destination);
            }
        }
    }


}
