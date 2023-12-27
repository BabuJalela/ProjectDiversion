using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    public GameInputs inputActions;
    public CharacterController characterController;
    public Animator animator;
    public Camera mainCamera;
    public float transitionMultiplier = 10f;

    private Vector3 playerMove;
    private bool playerSprint;
    private Vector2 mouseDelta;
    private Vector3 moveDirection;
    public float moveSpeed;
    public float sprintSpeed;
    private float gravity = -9.8f;
    /*private float velocityX = 0.0f;
    private float velocityZ = 0.0f;*/
    private int velocityXHash;
    private int velocityZHash;

    private void OnEnable()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
        characterController = GetComponent<CharacterController>();
        inputActions = new GameInputs();
        inputActions.Enable();
        inputActions.LocoMotion.Movements.started += GetMove;
        inputActions.LocoMotion.Movements.performed += GetMove;
        inputActions.LocoMotion.Movements.canceled += GetMove;

        inputActions.LocoMotion.Sprint.started += Sprint;
        inputActions.LocoMotion.Sprint.performed += Sprint;
        inputActions.LocoMotion.Sprint.canceled += Sprint;

        inputActions.LocoMotion.Mouse.started += Mouse;
        inputActions.LocoMotion.Mouse.performed += Mouse;
        inputActions.LocoMotion.Mouse.canceled += Mouse;
    }


    private void GetMove(InputAction.CallbackContext context)
    {
        playerMove.x = context.ReadValue<Vector2>().x;
        playerMove.y = gravity;
        playerMove.z = context.ReadValue<Vector2>().y;
    }
    private void Sprint(InputAction.CallbackContext context)
    {
        playerSprint = context.ReadValueAsButton();
    }

    private void Mouse(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Move();
        animations();
    }
    private void Move()
    {
        Debug.Log(playerMove);

        moveDirection = transform.TransformVector(playerMove);
        if (playerSprint)
        {
            characterController.SimpleMove(sprintSpeed * moveDirection);
        }
        else
        {
            characterController.SimpleMove(moveSpeed * moveDirection);
        }
    }

    private void animations()
    {
        Vector2 intended = new Vector2(playerMove.x, playerMove.z);
        intended /= (playerSprint ? 1f : 2f);

        Vector2 currentValue = new Vector2(animator.GetFloat("VelocityX"), animator.GetFloat("VelocityZ"));

        Vector2 result = Vector2.Lerp(currentValue, intended, transitionMultiplier * Time.deltaTime);

        animator.SetFloat("VelocityX", result.x);
        animator.SetFloat("VelocityZ", result.y);
    }

    private void LateUpdate()
    {
        Vector3 facingDirection = Vector3.Cross(mainCamera.transform.right, Vector3.up);
        transform.forward = facingDirection.normalized;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.LocoMotion.Movements.started -= GetMove;
        inputActions.LocoMotion.Movements.performed -= GetMove;
        inputActions.LocoMotion.Movements.canceled -= GetMove;

        inputActions.LocoMotion.Sprint.started += Sprint;
        inputActions.LocoMotion.Sprint.performed += Sprint;
        inputActions.LocoMotion.Sprint.canceled += Sprint;

        inputActions.LocoMotion.Mouse.started -= Mouse;
        inputActions.LocoMotion.Mouse.performed -= Mouse;
        inputActions.LocoMotion.Mouse.canceled -= Mouse;
    }
}
