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
    public float a;
    public float b;
    public float lerpValue;
    public float result;
    private void Update()
    {
        result = Mathf.Lerp(a, b, lerpValue);
        Debug.Log(result);

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

        /*if ((playerMove.x > 0 || playerMove.z > 0) || (playerMove.x < 0 || playerMove.z < 0))
        {
            animations();
        }
        else
        {
            animator.SetFloat(velocityXHash, 0);
            animator.SetFloat(velocityZHash, 0);
        }*/
    }

    private void animations()
    {
        Vector2 intended = new Vector2(playerMove.x, playerMove.z);
        intended /= (playerSprint ? 1f : 2f);

        Vector2 currentValue = new Vector2(animator.GetFloat("VelocityX"), animator.GetFloat("VelocityZ"));

        Vector2 result = Vector2.Lerp(currentValue, intended, transitionMultiplier * Time.deltaTime);

        animator.SetFloat("VelocityX", result.x);
        animator.SetFloat("VelocityZ", result.y);

        /*

        //animator.SetFloat(velocityXHash, Mathf.Lerp(velocityXHash, playerMove.x, 1 * Time.deltaTime));
        //animator.SetFloat(velocityZHash, Mathf.Lerp(velocityZHash, playerMove.z, 1 * Time.deltaTime));

        bool idle = playerMove.x == 0.0f && playerMove.z == 0.0f;
        bool forward = playerMove.z > 0.0f && playerMove.z <= 1f;
        bool backward = playerMove.z < 0.0f && playerMove.z >= -1f;
        bool right = playerMove.x > 0.0f && playerMove.x <= 1f;
        bool left = playerMove.x < 0.0f && playerMove.x >= -1f;

        float idleAnimValue = 0.0f;
        float walkAnimValue = 0.5f;
        float runAnimValue = 1f;

        //animator.SetFloat(velocityZHash, Mathf.Lerp(velocityZHash, playerSprint ? playerMove.z /))

        if (idle)
        {
            animator.SetFloat(velocityXHash, idleAnimValue);
            animator.SetFloat(velocityZHash, idleAnimValue);
        }
        if (forward)
        {
            animator.SetFloat(velocityXHash, idleAnimValue);
            animator.SetFloat(velocityZHash, walkAnimValue);
            if (forward && playerSprint)
            {
                animator.SetFloat(velocityXHash, idleAnimValue);
                animator.SetFloat(velocityZHash, runAnimValue);
            }
        }
        if (backward)
        {
            animator.SetFloat(velocityXHash, idleAnimValue);
            animator.SetFloat(velocityZHash, -walkAnimValue);
        }
        if (right)
        {
            animator.SetFloat(velocityXHash, walkAnimValue);
            animator.SetFloat(velocityZHash, idleAnimValue);
            if (right && playerSprint)
            {
                animator.SetFloat(velocityXHash, runAnimValue);
                animator.SetFloat(velocityZHash, idleAnimValue);
            }
        }
        if (left)
        {
            animator.SetFloat(velocityXHash, -walkAnimValue);
            animator.SetFloat(velocityZHash, idleAnimValue);
            if (left && playerSprint)
            {
                animator.SetFloat(velocityXHash, -runAnimValue);
                animator.SetFloat(velocityZHash, idleAnimValue);
            }
        }
        */
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
    /*        if 0.0f idle
          0.5 walk right, 1 run right -x axis
          - 0.5 walk left, -1 run left -x axis
          0.5 walk right, 1 run right -y axis
          0.5 walk right -y axis

          remove hardCode Values*/

    /* bool idle = playerMove.x == 0.0f && playerMove.z == 0.0f;
     bool forward = playerMove.z > 0.0f && playerMove.z <= 1f;
     bool backward = playerMove.z < 0.0f && playerMove.z >= -1f;
     bool right = playerMove.x > 0.0f && playerMove.x <= 1f;
     bool left = playerMove.x < 0.0f && playerMove.x >= -1f;

     bool idleAnim = velocityX == 0.0f && velocityZ == 0.0f;
     bool walkForwardAnim = velocityZ > 0.0f && velocityZ <= 0.5f;
     bool runForwardAnim = velocityZ > 0.5f && velocityZ <= 1f;
     bool walkBackwardAnim = velocityZ < 0.0f && velocityZ >= -0.5f;
     bool walkRightAnim = velocityX > 0.0f && velocityX <= 0.5f;
     bool runRightAnim = velocityX > 0.5f && velocityX <= 1f;
     bool walkLeftAnim = velocityX < 0.0f && velocityX >= -0.5f;
     bool runLeftAnim = velocityX < -0.5f && velocityX >= -1f;

     velocityX = playerMove.x;
     velocityZ = playerMove.z;*/

    /*if (idleAnim && idle)
    {
        Debug.Log("idle");

        velocityX = playerMove.x;
        velocityZ = playerMove.z;

    }
    if (forward && walkForwardAnim)
    {
        Debug.Log("forward");
        velocityX = playerMove.x / 2;
    }
    if (backward && walkBackwardAnim)
    {
        Debug.Log("backward");
    }
    if (left && walkLeftAnim)
    {
        Debug.Log("left");
    }
    if (right && walkRightAnim)
    {
        Debug.Log("right");
    }*/

}
