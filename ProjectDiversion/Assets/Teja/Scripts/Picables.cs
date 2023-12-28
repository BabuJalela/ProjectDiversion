using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Picables : MonoBehaviour
{
    public Rigidbody rb;
    private Transform objectgrabpointtransform;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   


    public void Grab(Transform objectgrabpointtransform)
    {
        this.objectgrabpointtransform = objectgrabpointtransform;
       
        rb.useGravity = false;
    }

    public void drop()
    {
        this.objectgrabpointtransform = null;
       
        rb.useGravity = true; 
    }

    private void FixedUpdate()
    {
        if (objectgrabpointtransform != null) 
        {
            float lerpspeed = 10f;
            Vector3 newsposition =  Vector3.Lerp(transform.position, objectgrabpointtransform.position, Time.deltaTime * lerpspeed);
            rb.MovePosition(newsposition);

        }
    }

    
}
