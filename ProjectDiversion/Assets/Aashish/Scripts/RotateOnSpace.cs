using UnityEngine;

public class RotateOnSpace : MonoBehaviour
{
    private float initialRotationX = 0f;
    private float initialRotationY = 0f;
    private float initialRotationZ = 0f;

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
}
