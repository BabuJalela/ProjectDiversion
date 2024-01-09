using UnityEngine;
using UnityEngine.AI;


public class EnemyPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public LayerMask playerLayer;
    public float detectionRange = 10f;
    public float raydistance = 5f;
    private NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject playerPrefab;
    public float stoppingDistance = 5f;
    public Transform raycastpoint;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();
    }

    void Update()
    {
        if (WarnPlayer())
        {
            Debug.Log("run away");
            MoveSlow();
        }
        else
        {
            SetNextPatrolPoint();
        }

        RaycastHit hit;
        if (Physics.Raycast(raycastpoint.transform.position, transform.forward, out hit, raydistance, playerLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * raydistance, Color.red);
            PlayerCaught();

        }
        else
        {
            Debug.DrawRay(raycastpoint.transform.position, transform.forward * raydistance, Color.green);
        }
    }

    bool WarnPlayer()
    {
        float distancetoplayer = Vector3.Distance(transform.position, player.position);
        return distancetoplayer <= detectionRange;
    }

    private void MoveSlow()
    {
        Debug.Log("orey ajmo lagetharoi");
        navMeshAgent.speed = 1f;
        navMeshAgent.SetDestination(player.position);
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
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You cauht again");

        }
    }

}

