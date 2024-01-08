using DG.Tweening;
using DialogueEditor;
using UnityEngine;
using UnityEngine.AI;

public class GoodPatrolEnemy : MonoBehaviour
{
    public Transform[] patrolWaypoint;
    public float patrolSpeed = 3f;
   // public float chaseSpeed = 5f;
    public float stoppingDistance = 2f;
    public LayerMask playerMask;
    public float dectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;
    public Transform player;
   // public Canvas WarnigCanvas;
    [SerializeField] private NPCConversation npcConversation;
   

    private void Start()
    {
     //   WarnigCanvas.gameObject.SetActive(false);
        navMeshAgent = GetComponent<NavMeshAgent>();
        Setnextwaypoint();

    }

    private void Update()
    {
       // if(Dectedplayer())
       // {
         //  Chaseplayer();
      //  }
      //  else
       // {
            Patrol();
          
       // }
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

    //bool Dectedplayer()
    //{
    //    float distancetoplayer = Vector3.Distance(transform.position, player.position);
    //    navMeshAgent.isStopped = true;
    //    return distancetoplayer <= dectionRange;


    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            ConversationManager.Instance.StartConversation(npcConversation);
            navMeshAgent.isStopped = false;

        }
       
    }

    //void Chaseplayer()
    //{
    //    navMeshAgent.speed = chaseSpeed;
    //    navMeshAgent.destination = player.position;

    //    if(Vector3.Distance(transform.position,player.position) <= stoppingDistance) 
    //    {
    //        navMeshAgent.isStopped = true;
    //        WarnigCanvas.gameObject.SetActive(true);
    //    }
    //    else 
    //    {
    //        navMeshAgent.isStopped = false;
    //    }
    //}
}
