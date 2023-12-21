using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Note : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float DisplayTime = 3f;
    public Transform textDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Moveup();
        }
    }

    private void Moveup()
    {
        transform.DOLocalMoveY(-2.6f, moveSpeed).OnComplete(DisplayText);
    }

    private void DisplayText()
    {
        textDisplay.gameObject.SetActive(true);
        Invoke("Hidetext" , DisplayTime);
    }

    private void Hidetext()
    {
        textDisplay?.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
