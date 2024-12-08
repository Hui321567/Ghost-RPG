using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{   
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            Vector3 randomSpot = Random.insideUnitSphere * 20f;
            NavMeshHit navHit;
            NavMesh.SamplePosition(transform.position + randomSpot, out navHit,10f,NavMesh.AllAreas);
            agent.SetDestination(navHit.position);
        }
    }
}
