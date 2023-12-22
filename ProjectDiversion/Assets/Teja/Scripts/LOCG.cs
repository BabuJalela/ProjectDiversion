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
//2004 - 2005 year - 8.5lakhs  bills - 10 lakhs * 7000
//1998 year - 
//ifss  utib0002178
// acc 921010036475851