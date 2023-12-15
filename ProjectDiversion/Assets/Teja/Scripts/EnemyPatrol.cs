using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public LayerMask playerLayer;
    public float detectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 10f;
    public Transform player;
    public float shootcooldown = 2f;
    public float nextshootime = 0f;
    private bool canshoot = true;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();
    }

    void Update()
    {
        if (detectplayer())
        {
            chaseplayer();
           //ShootAtPlayer();
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
                ShootAtPlayer();
            }
        }
    }

    bool detectplayer()
    {
        float distancetoplayer = Vector3.Distance(transform.position, player.position);
        return distancetoplayer <= detectionRange;
    }

     void chaseplayer()
     {
        navMeshAgent.destination = player.position;
     }


    void Patrol()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            SetNextPatrolPoint();
        }
    }

    void SetNextPatrolPoint()
    {
        navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void ShootAtPlayer()
    {
       if(canshoot && Time.time >= nextshootime) 
       {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bullterb = bullet.GetComponent<Rigidbody>();
            bullterb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

            canshoot = false;
            nextshootime = Time.time + shootcooldown;
       }

       if (!canshoot && Time.time >= nextshootime) 
       {
            canshoot = true;
       }
    }
}//9885851621 - santhosh ca AJDPN5795P
//8712928621 MURTHY GARU

