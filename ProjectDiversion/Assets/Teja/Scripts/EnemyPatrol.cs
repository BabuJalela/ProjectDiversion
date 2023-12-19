using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    public LayerMask playerLayer;
    public float detectionRange = 10f;
    private NavMeshAgent navMeshAgent;
    public Transform player;
    //public Transform firePoint;
    //public float bulletForce = 10f;
    //public float shootcooldown = 2f;
    //public float nextshootime = 0f;
    //public GameObject bulletPrefab;
    //private bool canshoot = true;

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

        Debug.Log("You Caught");
       //if(canshoot && Time.time >= nextshootime) 
       //{
       //     GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);           
       //     Rigidbody bullterb = bullet.GetComponent<Rigidbody>();
       //     bullterb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

       //     canshoot = false;
       //     nextshootime = Time.time + shootcooldown;
       //}

       //if (!canshoot && Time.time >= nextshootime) 
       //{
       //     canshoot = true;
       //}
    }

    /*public void Spawn(Vector3 spawnposition)
    {
        transform.position = spawnposition;
        gameObject.SetActive(true)
    }*/
}

