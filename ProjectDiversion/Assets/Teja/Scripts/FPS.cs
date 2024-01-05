using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public static FPS Instance;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private CharacterController characterController;
    private float normalCharacterControllerHeight;
    public float crouchHeight = 0.5f;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    public bool Ismoving = false;
    private bool iscrouching = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        normalCharacterControllerHeight = characterController.height;
    }

    void Update()
    {
        PlayerMovement();
        HadelCrouchInput();
    }

    void HadelCrouchInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCrouch();
        }
    }

    void ToggleCrouch()
    {
        iscrouching = !iscrouching;
        if(iscrouching)
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }

    void Crouch()
    {
        characterController.height = crouchHeight;
    }

    void StandUp()
    {
        characterController.height = normalCharacterControllerHeight;
    }
    public void PlayerMovement()
    {
        Ismoving = true;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
        characterController.SimpleMove(moveDirection * moveSpeed);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

}
