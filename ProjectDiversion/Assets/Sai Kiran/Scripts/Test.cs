using UnityEngine;

public class Test : MonoBehaviour
{

    public float moveSpeed = 5f; // Adjust the speed in the Inspector

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;

        // Get the current position of the player
        Vector3 currentPosition = transform.position;

        // Calculate the new position based on input and speed
        Vector3 newPosition = currentPosition + movement;

        // Update the player's position directly
        transform.position = newPosition;
    }
}


