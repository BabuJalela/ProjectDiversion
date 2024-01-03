using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCam : MonoBehaviour
{
    private GameObject MainCam;
    private GameObject ObjCam;

    private void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
        ObjCam = GameObject.FindGameObjectWithTag("ObjCam");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MainCam.SetActive(false);
            ObjCam.SetActive(true);
        }
        else
        {
            MainCam.SetActive(true);
            ObjCam.SetActive(false);
        }
    }
}
