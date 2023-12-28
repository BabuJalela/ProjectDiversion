using UnityEngine;

public class RotateOnSpace : MonoBehaviour
{
    private float initialRotationX = 0f;
    private float initialRotationY = 0f;
    private float initialRotationZ = 0f;
    private Quaternion targetRotation;

    private bool startRotation = false;

    public float rotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        rotate();
    }

    public void rotate()
    {
        if (startRotation)
        { 
            targetRotation = Quaternion.Euler(initialRotationX, initialRotationY, initialRotationZ);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void yesRotate()
    {
        startRotation = true;
    }

    public void noRotate()
    {
        startRotation = false;
    }
}
