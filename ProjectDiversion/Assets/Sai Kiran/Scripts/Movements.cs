using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    [SerializeField] private GameInputs inputActions;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float transitionMultiplier = 10f;

    private Vector3 playerMove;
    private bool playerSprint;
    private Vector2 mouseDelta;
    private bool playerCrouch;
    private Vector3 moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    private int velocityXHash;
    private int velocityZHash;

    [SerializeField] private bool inWater;

    // IK
    [SerializeField] private Transform rightToHold;
    [SerializeField] private Transform leftToHold;
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
        inputActions.Player.Movements.started += MoveValues;
        inputActions.Player.Movements.performed += MoveValues;
        inputActions.Player.Movements.canceled += MoveValues;

        inputActions.Player.Sprint.started += SprintValue;
        inputActions.Player.Sprint.performed += SprintValue;
        inputActions.Player.Sprint.canceled += SprintValue;

        inputActions.Player.Mouse.started += MouseValues;
        inputActions.Player.Mouse.performed += MouseValues;
        inputActions.Player.Mouse.canceled += MouseValues;

        inputActions.Interactions.Crouch.started += CrouchValues;
        inputActions.Interactions.Crouch.performed += CrouchValues;
        inputActions.Interactions.Crouch.canceled += CrouchValues;
    }


    private void MoveValues(InputAction.CallbackContext context)
    {
        playerMove.x = context.ReadValue<Vector2>().x;
        playerMove.z = context.ReadValue<Vector2>().y;
    }

    private void MouseValues(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    private void SprintValue(InputAction.CallbackContext context)
    {
        playerSprint = context.ReadValueAsButton();
    }
    private void CrouchValues(InputAction.CallbackContext context)
    {
        playerCrouch = context.ReadValueAsButton();
    }

    private void Update()
    {
        Move();
        animations();
    }
    private void Move()
    {
        //Debug.Log(playerMove);

        moveDirection = transform.TransformVector(playerMove);
        if (playerSprint)
        {
            characterController.Move(sprintSpeed * Time.deltaTime * moveDirection);
        }
        else
        {
            characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
        }
    }

    private void Crouch()
    {

    }
    /*private void OnAnimatorIK()
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
    }*/

    private void animations()
    {
        Vector2 intended = new Vector2(playerMove.x, playerMove.z);
        intended /= (playerSprint ? 1f : 2f);

        Vector2 currentValue = new Vector2(animator.GetFloat("VelocityX"), animator.GetFloat("VelocityZ"));

        Vector2 result = Vector2.Lerp(currentValue, intended, transitionMultiplier * Time.deltaTime);

        animator.SetFloat("VelocityX", result.x);
        animator.SetFloat("VelocityZ", result.y);

        if (playerCrouch && !inWater)
        {
            animator.SetBool("Crouch", true);
            animator.SetFloat("VelocityX", playerMove.x);
            animator.SetFloat("VelocityZ", playerMove.z);
        }
        else
        {
            animator.SetBool("Crouch", false);
        }
        if (inWater)
        {
            animator.SetBool("InWater", true);
            animator.SetFloat("VelocityX", result.x);
            animator.SetFloat("VelocityZ", result.y);
        }
        else
        {
            animator.SetBool("InWater", false);
        }
    }

    private void LateUpdate()
    {
        Vector3 facingDirection = Vector3.Cross(mainCamera.transform.right, Vector3.up);
        transform.forward = facingDirection.normalized;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Movements.started -= MoveValues;
        inputActions.Player.Movements.performed -= MoveValues;
        inputActions.Player.Movements.canceled -= MoveValues;

        inputActions.Player.Sprint.started += SprintValue;
        inputActions.Player.Sprint.performed += SprintValue;
        inputActions.Player.Sprint.canceled += SprintValue;

        inputActions.Player.Mouse.started -= MouseValues;
        inputActions.Player.Mouse.performed -= MouseValues;
        inputActions.Player.Mouse.canceled -= MouseValues;

        inputActions.Interactions.Crouch.started += CrouchValues;
        inputActions.Interactions.Crouch.performed += CrouchValues;
        inputActions.Interactions.Crouch.canceled += CrouchValues;
    }
}
