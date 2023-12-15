using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyEscape : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;
    public FPS playermovement;
    public Transform[] waypoints;
    public float waypointsstoppingdis = 1f;
    private int currentwaypointindex = 0;
    public AudioClip PlayerCaughtAudio;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (playermovement.Ismoving)
        {

            FollowPlayer();
        }
        else
        {

            MoveBetweenWayPoints();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(PlayerCaughtAudio);


        }
    }
   

    private void FollowPlayer()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void MoveBetweenWayPoints()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("no waypoints ra assign chesko");
            return;
        }

        navMeshAgent.SetDestination(waypoints[currentwaypointindex].position);

        if (Vector3.Distance(transform.position, waypoints[currentwaypointindex].position) < waypointsstoppingdis)
        {
            currentwaypointindex = (currentwaypointindex + 1) % waypoints.Length;
        }
    }
}
