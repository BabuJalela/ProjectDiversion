using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCam : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCam;
    [SerializeField] private GameObject ObjCam;
    [SerializeField] private GameObject Bird;
    [SerializeField] private GameObject FakeBird;

    private void Start()
    {
        ObjCam.SetActive(false);
        PlayerCam.SetActive(true);
        Bird.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayerCam.SetActive(false);
                ObjCam.SetActive(true);
                Bird.SetActive(true);
                FakeBird.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerCam.SetActive(true);
            ObjCam.SetActive(false);
        }
    }
}
