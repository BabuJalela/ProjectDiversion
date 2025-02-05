using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectivesTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;

    public CinemachineVirtualCamera a1;
    public CinemachineVirtualCamera a2;
    public CinemachineVirtualCamera a3;
    public CinemachineVirtualCamera a4;
    public CinemachineVirtualCamera a5;
    public CinemachineVirtualCamera a6;

    public Collider t1;
    public Collider t2;
    public Collider t3;
    public Collider t4;
    public Collider t5;
    public Collider t6;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DeactivateALLPanelsAndCameras();

            switch (gameObject.tag) 
            {        
                
                case "Run into the village objective":
                    a2.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea2());
                    p2.SetActive(true);
                    Destroy(t2);
                    Debug.Log("Run into the village objective panel activated");
                    break;
                case "Intraction Objective":
                    a3.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea3());
                    p3.SetActive(true);
                    Destroy(t3);
                    Debug.Log("Intraction Objective panel activated");
                    break;
                case "Key room objective":
                    a5.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea5());
                    p5.SetActive(true);
                    Destroy(t5);
                    Debug.Log("Key room objective panel activated");
                    break;
                case "Well & pumhouse objective":
                    a6.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea6());
                    p6.SetActive(true);
                    Destroy(t6);
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

            DeactivateALLPanelsAndCameras();

            switch (gameObject.tag)
            {
                case "Wakeup objective":
                    a1.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea1());
                    p1.SetActive(true);
                    Destroy(t1);
                    Debug.Log("Wakeup objective panel activated");
                    break;
                case "Main manision objective":
                    a4.gameObject.SetActive(true);
                    player.SetActive(false);
                    StartCoroutine(FinishCutScenea4());
                    p4.SetActive(true);
                    Destroy(t4);
                    Debug.Log("Main manision objective panel activated");
                    break;


            }
        }
    }

   public void DeactivateALLPanelsAndCameras()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        p5.SetActive(false);
        p6.SetActive(false);

        a1.gameObject.SetActive(false);
        a2.gameObject.SetActive(false);
        a3.gameObject.SetActive(false);
        a4.gameObject.SetActive(false);
        a5.gameObject.SetActive(false);
        a6.gameObject.SetActive(false);

        Debug.Log("all panels deactivated");
    }

    IEnumerator FinishCutScenea1()
    {
        yield return new WaitForSeconds(11);
        a1.gameObject.SetActive(false);
        player.SetActive(true);
        p1.SetActive(false);
    }
    IEnumerator FinishCutScenea2()
    {
        yield return new WaitForSeconds(28);
        a2.gameObject.SetActive(false);
        player.SetActive(true);
        p2.SetActive(false);
    }
    IEnumerator FinishCutScenea3()
    {
        yield return new WaitForSeconds(24);
        a3.gameObject.SetActive(false);
        player.SetActive(true);
        p3.SetActive(false);
    }
    IEnumerator FinishCutScenea4()
    {
        yield return new WaitForSeconds(26);
        a4.gameObject.SetActive(false);
        player.SetActive(true);
        p4.SetActive(false);
    }
    IEnumerator FinishCutScenea5()
    {
        yield return new WaitForSeconds(27);
        a5.gameObject.SetActive(false);
        player.SetActive(true);
        p5.SetActive(false);
    }
    IEnumerator FinishCutScenea6()
    {
        yield return new WaitForSeconds(9);
        a6.gameObject.SetActive(false);
        player.SetActive(true);
        p6.SetActive(false);
    }

}
