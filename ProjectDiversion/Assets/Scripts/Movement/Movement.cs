using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform orientation;
    public float rotationSpeed = 10f;
    public float moveSpeed = 6f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.2f;

    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;
    private bool jumpInput;

    private void Update()
    {
        HandleInput();
        HandleOrientation();
        HandleMovement();
        HandleJump();
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetButtonDown("Jump");
    }

    private void HandleOrientation()
    {
        Vector3 viewDir = orientation.forward;
        viewDir.y = 0;
        Quaternion toRotation = Quaternion.LookRotation(viewDir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;
        moveDirection.y = 0;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void HandleJump()
    {
        if (jumpInput && IsGrounded())
        {
            float jumpVelocity = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics.gravity.y));
            transform.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpVelocity, 0);
        }
    }

    private bool IsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance + 0.1f);
        return isGrounded;
    }
}
