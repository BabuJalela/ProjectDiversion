using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Note : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float DisplayTime = 3f;
   // public Transform textDisplay;
   // public GameObject specialtreeSET;
    public bool isCollected = false;


    private void Start()
    {
       // specialtreeSET.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            Moveup();
        }
    }

    private void Moveup()
    {
        transform.DOLocalMoveY(-2.6f, moveSpeed);//.OnComplete(DisplayText);
    }

   // private void DisplayText()
   // {
   //     specialtreeSET.SetActive(true);
   //     textDisplay.gameObject.SetActive(true);
   //     Invoke("Hidetext" , DisplayTime);
   // }

    //private void Hidetext()
   // {
   //     textDisplay?.gameObject.SetActive(false);
     //   Destroy(gameObject);
   // }

}
