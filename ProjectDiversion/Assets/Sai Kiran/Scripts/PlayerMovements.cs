using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovements : MonoBehaviour
{
    private CharacterController characterController;
    private Camera playerCamera;
    public Animator animator;
    public ActionMap inputActions;

    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;

    float horizontalInput;
    float verticalInput;
    float mouseX;
    float mouseY;
    public float verticalRotationAngle;
    Vector3 moveDirection;


    private void OnEnable()
    {
        inputActions.LocoMotion.Movements.started += Move;
        inputActions.LocoMotion.Movements.performed += Move;
        inputActions.LocoMotion.Movements.canceled += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {

    }

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCamera = GetComponentInChildren<Camera>();

    }

    void Update()
    {
        Move();
        MouseMove();
        animations();
    }
    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
        characterController.SimpleMove(moveDirection * moveSpeed * Time.deltaTime);

    }
    private void MouseMove()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationAngle, verticalRotationAngle);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }
    private void animations()
    {
        float moveMagnitude = moveDirection.magnitude;
        animator.SetFloat("Move", moveMagnitude);
    }
}
