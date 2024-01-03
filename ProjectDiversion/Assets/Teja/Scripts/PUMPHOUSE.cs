using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMPHOUSE : MonoBehaviour
{
   
    public GameObject player;
    public GameObject VR;

    private void Start()
    {
        
        VR.gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.SetActive(false);
            VR.gameObject.SetActive(true);
        }
    }
}
