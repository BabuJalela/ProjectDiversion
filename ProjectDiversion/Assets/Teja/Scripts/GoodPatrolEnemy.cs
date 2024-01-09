using DG.Tweening;
using DialogueEditor;
using UnityEngine;
using UnityEngine.AI;

public class GoodPatrolEnemy : MonoBehaviour
{
    public Transform[] patrolWaypoint;
    public float patrolSpeed = 3f;
    public float dectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;
    public Transform player;
    [SerializeField] private NPCConversation npcConversation;
   

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Setnextwaypoint();

    }

    private void Update()
    {     
      Patrol();
    }

    void Patrol()
    {
        navMeshAgent.speed = patrolSpeed;
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            Setnextwaypoint();
        }
    }

    void Setnextwaypoint()
    {
        navMeshAgent.destination = patrolWaypoint[currentWaypointIndex].position;
        if (Vector3.Distance(patrolWaypoint[currentWaypointIndex].transform.position, transform.position) < 1)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoint.Length;
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            ConversationManager.Instance.StartConversation(npcConversation);
            navMeshAgent.isStopped = false;

        }
       
    }

    
}
