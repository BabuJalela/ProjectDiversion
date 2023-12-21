using UnityEngine;
using UnityEngine.AI;


public class EnemyPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public LayerMask playerLayer;
    public float detectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject playerPrefab;
    public float stoppingDistance = 5f;
   

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
        navMeshAgent.speed = 5;
    }



    void Patrol()
    {
            SetNextPatrolPoint();
      
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

        Debug.Log("You Caught");

        if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
        {
            navMeshAgent.isStopped = true;
            //WarnigCanvas.gameObject.SetActive(true);
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
        // just for testing
        Destroy(playerPrefab, 2f);

    }
    //2.5 - L;
   
}

 