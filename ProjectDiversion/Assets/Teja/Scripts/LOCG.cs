using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOCG : MonoBehaviour
{
    public GameObject GoodPatrol;


    private void Start()
    {
        GoodPatrol.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GoodPatrol.SetActive(true);

    }
}
