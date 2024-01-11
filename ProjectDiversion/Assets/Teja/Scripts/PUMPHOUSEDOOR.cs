using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUMPHOUSEDOOR : MonoBehaviour
{
    private float initialRotationX = 0f;
    public float initialRotationY = 0f;
    private float initialRotationZ = 0f;
    private bool isfire = false;    

    private Quaternion targetRotation;

    public float rotationSpeed = 60f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                targetRotation = Quaternion.Euler(initialRotationX, initialRotationY, initialRotationZ);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Opendoors()
    {

        targetRotation = Quaternion.Euler(initialRotationX, initialRotationY, initialRotationZ);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if(isfire)
        {
            Opendoors();

        }
    }

    public void CanOpen() 
    {
        isfire = true; 
    }
}
