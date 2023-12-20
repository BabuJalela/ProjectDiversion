using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PatrolHead : MonoBehaviour
{
    public GameObject warning;
    public float activationrange;
    public Collider killcollider;
    public GameObject[] enemies;

    private void Update()
    {
        Activatewarning();
    }

    private void Activatewarning()
    {
        float distancetoplayer = Vector3.Distance(transform.position, FPS.Instance.transform.position);

        if (distancetoplayer <= activationrange)
        {
            if (warning != null) 
            {
                warning.SetActive(true);
            }
        }
        else
        {
            if (warning != null)
            {
                warning.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sendmessagetoenemies("movefaster");
        }
    }

    public void sendmessagetoenemies(string message)
    {
       // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies) 
        {
            enemy.SendMessage(message,SendMessageOptions.DontRequireReceiver);
        }
    }
}
