using UnityEngine;

public class SignRotation : MonoBehaviour
{
    public float initialRotationX = 0f;
    public float initialRotationY = 0f;
    public float initialRotationZ = 0f;

    private bool rotateSign = false;

    private Quaternion targetRotation;

    public float rotationSpeed = 60f;

    void Start()
    {
        
    }

    void Update()
    {
        rotate();
    }

    public void rotate()
    {
        if(rotateSign) 
        { 
            targetRotation = Quaternion.Euler(initialRotationX, initialRotationY, initialRotationZ);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void yesRotate()
    {
        rotateSign = true;
    }

    public void noRotate()
    {
        rotateSign = false;
    }

}
