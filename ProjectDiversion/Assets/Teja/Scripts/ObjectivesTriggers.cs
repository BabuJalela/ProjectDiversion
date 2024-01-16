using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesTriggers : MonoBehaviour
{
   // public GameObject p1;
   // public GameObject p2;
   // public GameObject p3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DeactivateALLPanels();

            //if(gameObject.CompareTag("Trigger1"))
            //{
            //    //p1.SetActive(true);
            //    Debug.Log("panel1 activated");
            //}
            //else if(gameObject.CompareTag("Trigger2"))
            //{
            //    //p2.SetActive(true);
            //    Debug.Log("panel2 activated");
            //}
            //else if(gameObject.CompareTag("Trigger3"))
            //{
            //    //p3.SetActive(true);
            //    Debug.Log("panel3 activated");
            //}

            switch (gameObject.tag) 
            {
                case "Trigger1":
                    Debug.Log("panel1 activated");
                    break;
                case "Trigger2":
                    Debug.Log("panel2 activated");
                    break;
                case "Trigger3":
                    Debug.Log("panel3 activated");
                    break;

                default:
                    break;
            }


        }
    }

    void DeactivateALLPanels()
    {
        //p1.SetActive(false);
        //p2.SetActive(false);
        //p3.SetActive(false);
        Debug.Log("all panels deactivated");
    }

}
