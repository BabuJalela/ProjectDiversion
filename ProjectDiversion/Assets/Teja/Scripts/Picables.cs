using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Picables : MonoBehaviour
{
    public Rigidbody rb;
    private Transform objectgrabpointtransform;
    public Material outlinemat;
    private Renderer objectrender;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        objectrender = GetComponent<Renderer>();
    }


    public void Grab(Transform objectgrabpointtransform)
    {
        this.objectgrabpointtransform = objectgrabpointtransform;
       // togglematerial();
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

    public void togglematerial()
    {
        if (outlinemat != null && objectrender != null)
        {
            Material[] materials = objectrender.materials;
            ArrayUtility.Add(ref materials, outlinemat);
            objectrender.materials = materials;
        }
    }
}
