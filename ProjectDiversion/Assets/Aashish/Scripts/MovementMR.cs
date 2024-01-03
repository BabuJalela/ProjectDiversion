using UnityEngine;

public class MovementMR : MonoBehaviour
{
    public Transform orientation;
    public Transform playerTransform;
    public Transform cameraTransform;

    public float rotationSpeed = 10f;
    public float moveSpeed = 6f;
    public float sprintSpeed = 12f;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private float horizontalInput;
    private float verticalInput;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        KeyBoardInput();
        MouseLook();
        Movement();
    }

    private void KeyBoardInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerTransform.Rotate(Vector3.up * mouseX);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

    }

    private void Movement()
    {        
        Vector3 moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;
        moveDirection.y = 0;

        if (moveDirection.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
