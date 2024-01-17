using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMarker : MonoBehaviour
{
    public float duration = 1f;
   // public Transform player;
    private void Start()
    {
        transform.DOMoveY(transform.position.y + 2, duration).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);               
    }

    //void Update()
    //{ 
    //    transform.LookAt(player.position);
    //}
}
