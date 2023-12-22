using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesTriggers : MonoBehaviour
{
    public GameObject objectives;
    public float timetodestroy = 10f;

    private void Start()
    {
        objectives.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectives.SetActive(true);
        }
        Destroy(objectives, timetodestroy);
    }

    
}
