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
    private bool playerInteract;
    private Vector3 moveDirection;
    public float moveSpeed;
    public float sprintSpeed;
    //public float gravity = 9.8f;
    /*private float velocityX = 0.0f;
    private float velocityZ = 0.0f;*/
    private int velocityXHash;
    private int velocityZHash;

    // IK
    public Transform rightToHold;
    public Transform leftToHold;
    float positionweight = 0f;

    private void OnEnable()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputActions = new GameInputs();
        inputActions.Enable();
        inputActions.Player.Movements.started += GetMove;
        inputActions.Player.Movements.performed += GetMove;
        inputActions.Player.Movements.canceled += GetMove;

        inputActions.Player.Sprint.started += Sprint;
        inputActions.Player.Sprint.performed += Sprint;
        inputActions.Player.Sprint.canceled += Sprint;

        inputActions.Player.Mouse.started += Mouse;
        inputActions.Player.Mouse.performed += Mouse;
        inputActions.Player.Mouse.canceled += Mouse;

        inputActions.Player.Interactions.started += Interactions;
        inputActions.Player.Interactions.performed += Interactions;
        inputActions.Player.Interactions.canceled += Interactions;
    }


    private void GetMove(InputAction.CallbackContext context)
    {
        playerMove.x = context.ReadValue<Vector2>().x;
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
    private void Interactions(InputAction.CallbackContext context)
    {
        playerInteract = context.ReadValueAsButton();
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

    private void OnAnimatorIK()
    {
        if (animator)
        {
            if (playerInteract)
            {
                if (rightToHold != null && leftToHold != null)
                {
                    animator.Play("Braced Hang To Crouch");
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightToHold.position);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftToHold.position);

                    positionweight += Time.deltaTime;
                    positionweight = Mathf.Clamp(positionweight, 0f, 1f);
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, positionweight);
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, positionweight);
                }
            }
            else
            {
                positionweight -= Time.deltaTime;
                positionweight = Mathf.Clamp(positionweight, 0f, 1f);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, positionweight);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, positionweight);
            }
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
        inputActions.Player.Movements.started -= GetMove;
        inputActions.Player.Movements.performed -= GetMove;
        inputActions.Player.Movements.canceled -= GetMove;

        inputActions.Player.Sprint.started += Sprint;
        inputActions.Player.Sprint.performed += Sprint;
        inputActions.Player.Sprint.canceled += Sprint;

        inputActions.Player.Mouse.started -= Mouse;
        inputActions.Player.Mouse.performed -= Mouse;
        inputActions.Player.Mouse.canceled -= Mouse;

        inputActions.Player.Interactions.started -= Interactions;
        inputActions.Player.Interactions.performed -= Interactions;
        inputActions.Player.Interactions.canceled -= Interactions;
    }
}
