using UnityEngine;

public class MovementMR : MonoBehaviour
{
    public Transform orientation;
    public float rotationSpeed = 10f;
    public float moveSpeed = 6f;
    public float sprintSpeed = 12f;
    public float mouseSensitivity = 2f;

    private float horizontalInput;
    private float verticalInput;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        Vector3 viewDir = orientation.forward;
        viewDir.y = 0;

        Quaternion toRotation = Quaternion.LookRotation(viewDir, Vector3.up) * Quaternion.Euler(0, mouseX, 0);

        orientation.rotation = Quaternion.Slerp(orientation.rotation, toRotation, rotationSpeed * Time.deltaTime);
        orientation.rotation = toRotation;

    }

    private void HandleMovement()
    {        
        Vector3 moveDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;
        moveDirection.y = 0;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;


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
