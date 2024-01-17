using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesTriggers : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DeactivateALLPanels();

            switch (gameObject.tag) 
            {              
                case "Run into the village objective":
                    p2.SetActive(true);
                    Debug.Log("Run into the village objective panel activated");
                    break;
                case "Intraction Objective":
                    p3.SetActive(true);
                    Debug.Log("Intraction Objective panel activated");
                    break;
                case "Key room objective":
                    p5.SetActive(true);
                    Debug.Log("Key room objective panel activated");
                    break;
                case "Well & pumhouse objective":
                    p6.SetActive(true);
                    Debug.Log("Well & pumhouse objective panel activated");
                    break;

                default:
                    break;
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            DeactivateALLPanels();

            switch (gameObject.tag)
            {
                case "Wakeup objective":
                    p1.SetActive(true);
                    Debug.Log("Wakeup objective panel activated");
                    break;
                case "Main manision objective":
                    p4.SetActive(true);
                    Debug.Log("Main manision objective panel activated");
                    break;


            }
        }
    }

    void DeactivateALLPanels()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p5.SetActive(false);
        p6.SetActive(false);
        Debug.Log("all panels deactivated");
    }

}
