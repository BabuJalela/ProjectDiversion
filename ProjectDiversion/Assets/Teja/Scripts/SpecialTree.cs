using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other .CompareTag("Player"))
        {
            Destroy(gameObject,3f);
        }
    }
}
