using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoodPatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public LayerMask playerLayer;
    public float detectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    public Transform player;
   

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();

    }

    void Update()
    {
        if (DetectPlayer())
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRange, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                PlayerCaught();
            }
        }
    }

    bool DetectPlayer()
    {
        float distancetoplayer = Vector3.Distance(transform.position, player.position);
        return distancetoplayer <= detectionRange;
    }
    void ChasePlayer()
    {
        Fast();
        navMeshAgent.destination = player.position;
    }
    public void Fast()
    {
        navMeshAgent.speed = 4;
    }



    void Patrol()
    {
        // if (navMeshAgent.remainingDistance < 0.5f)
        //{
        SetNextPatrolPoint();
        // }
    }

    void SetNextPatrolPoint()
    {
        navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;
        if (Vector3.Distance(patrolPoints[currentPatrolIndex].transform.position, transform.position) < 1)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void PlayerCaught()
    {

        Debug.Log("You Cannot go beoyend this point");
        
    }

   
}
