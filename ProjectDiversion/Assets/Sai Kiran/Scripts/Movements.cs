using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    [SerializeField] private GameInputs inputActions;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float animationTransitionMultiplier = 10f;

    private Vector3 playerMove;
    private Vector3 moveDirection;
    private bool playerSprint;
    private bool playerCrouch;
    private bool playerJump;
    [SerializeField] private float jumpHeight;
    private float jumpVelocity;
    public bool inWater;
    public bool stopPlayerMove;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    private float playerGravity = -9.81f;

    /* // IK
     [SerializeField] private Transform rightToHold;
     [SerializeField] private Transform leftToHold;
     float positionweight = 0f;*/

    private void OnEnable()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCrouch = false;

        inputActions = new GameInputs();
        inputActions.Enable();
        inputActions.Player.Movements.started += GetMoveValues;
        inputActions.Player.Movements.performed += GetMoveValues;
        inputActions.Player.Movements.canceled += GetMoveValues;

        inputActions.Player.Sprint.started += GetSprintValue;
        inputActions.Player.Sprint.performed += GetSprintValue;
        inputActions.Player.Sprint.canceled += GetSprintValue;

        inputActions.Player.Jump.started += GetJumpValue;
        inputActions.Player.Jump.performed += GetJumpValue;
        inputActions.Player.Jump.canceled += GetJumpValue;

        inputActions.Interactions.Crouch.started += GetCrouchValues;
        inputActions.Interactions.Crouch.performed += GetCrouchValues;
        inputActions.Interactions.Crouch.canceled += GetCrouchValues;
    }

    private void GetMoveValues(InputAction.CallbackContext context)
    {
        playerMove.x = context.ReadValue<Vector2>().x;
        playerMove.z = context.ReadValue<Vector2>().y;
    }
    private void GetSprintValue(InputAction.CallbackContext context)
    {
        playerSprint = context.ReadValueAsButton();
    }
    private void GetJumpValue(InputAction.CallbackContext context)
    {
        playerJump = context.ReadValueAsButton();
        //JumpLogic(playerJump);
    }
    private void GetCrouchValues(InputAction.CallbackContext context)
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
        if (stopPlayerMove)
        {
            playerMove.x = 0;
            playerMove.z = 0;
        }
        if (playerJump && characterController.isGrounded)
        {
            jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * playerGravity);
        }
        jumpVelocity += playerGravity * Time.deltaTime;
        /*else
        {
            playerGravity -= Time.deltaTime * 2f;
            playerGravity = Mathf.Clamp(playerGravity, 0f, -9.81f);
        }*/
        //Debug.Log(playerMove);
        float applyWalkSpeed;
        float applySprintSpeed;

        playerMove.y = inWater ? 0f : playerGravity;// player not floating
        playerMove.y = playerJump ? jumpVelocity : playerGravity;

        applyWalkSpeed = (inWater || playerCrouch) ? walkSpeed / 2 : walkSpeed;
        applySprintSpeed = (inWater || playerCrouch) ? sprintSpeed / 2 : sprintSpeed;

        //Debug.Log($"applywalk : {applyWalkSpeed}, applysprint : {applySprintSpeed}");

        moveDirection = transform.TransformVector(playerMove);
        if (playerSprint)
        {
            characterController.Move(applySprintSpeed * Time.deltaTime * moveDirection);
        }
        else
        {
            characterController.Move(applyWalkSpeed * Time.deltaTime * moveDirection);
        }
    }
    /*private void JumpLogic(bool _playerJump)
    {

    }*/

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

        Vector2 result = Vector2.Lerp(currentValue, intended, animationTransitionMultiplier * Time.deltaTime);

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
        if (playerJump)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
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
        inputActions.Player.Movements.started -= GetMoveValues;
        inputActions.Player.Movements.performed -= GetMoveValues;
        inputActions.Player.Movements.canceled -= GetMoveValues;

        inputActions.Player.Sprint.started -= GetSprintValue;
        inputActions.Player.Sprint.performed -= GetSprintValue;
        inputActions.Player.Sprint.canceled -= GetSprintValue;

        inputActions.Player.Jump.started -= GetJumpValue;
        inputActions.Player.Jump.performed -= GetJumpValue;
        inputActions.Player.Jump.canceled -= GetJumpValue;

        inputActions.Interactions.Crouch.started -= GetCrouchValues;
        inputActions.Interactions.Crouch.performed -= GetCrouchValues;
        inputActions.Interactions.Crouch.canceled -= GetCrouchValues;
    }
}
