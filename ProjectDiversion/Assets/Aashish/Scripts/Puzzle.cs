using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public RotateOnSpace rt;

    public Transform targetObject;
    public Transform referenceObject;

    public float rotationSpeed = 100f;
    public float threshold = 0.970f;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float angleSpeed = rotationSpeed * Time.deltaTime;

        Quaternion mouseRotation = Quaternion.AngleAxis(angleSpeed * mouseX, referenceObject.up) * Quaternion.AngleAxis(angleSpeed * mouseY, referenceObject.right);
        transform.rotation = mouseRotation * transform.rotation;

        float dotUp = Vector3.Dot(transform.up, targetObject.up);
        float dotRight = Vector3.Dot(transform.right, targetObject.right);

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(dotRight >= threshold && dotUp >= threshold) 
            {
                rt.yesRotate();
            }
            else
            {
                rt.noRotate();
            }
        }
    }
}
