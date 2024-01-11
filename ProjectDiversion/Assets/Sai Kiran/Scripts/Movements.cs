using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider capsuleCollider;
    private GameInputs inputActions;
    private Camera mainCamera;

    private Vector3 playerMove_;
    private Vector3 moveDirection;
    private Vector3 movement;
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private Vector2 intended;
    private Vector2 currentValue;
    private Vector2 result;
    private Vector3 facingDirection;
    [SerializeField] private Vector3 standCenter;
    [SerializeField] private Vector3 crouchCenter;


    private bool playerSprint_;
    private bool playerCrouch_;
    private bool playerJump_;
    public bool inWater;
    public bool stopPlayerMove;
    private bool isGrounded;

    [SerializeField] private float animationTransitionMultiplier = 10f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rayLength = 0.1f;
    [SerializeField] private float standHeight;
    [SerializeField] private float crouchHeight;

    private float applyWalkSpeed;
    private float applySprintSpeed;
    //[SerializeField] private float gravity = -9.81f;
    //private float jumpVelocity;
    /* // IK
     [SerializeField] private Transform rightToHold;
     [SerializeField] private Transform leftToHold;
     float positionweight = 0f;*/


    private void OnEnable()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCrouch_ = false;

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
        playerMove_.x = context.ReadValue<Vector2>().x;
        playerMove_.z = context.ReadValue<Vector2>().y;
    }
    private void GetSprintValue(InputAction.CallbackContext context)
    {
        playerSprint_ = context.ReadValueAsButton();
    }
    private void GetJumpValue(InputAction.CallbackContext context)
    {
        playerJump_ = context.ReadValueAsButton();
        if (context.performed)
            Jump();
    }
    private void GetCrouchValues(InputAction.CallbackContext context)
    {
        playerCrouch_ = context.ReadValueAsButton();
    }

    private void Update()
    {
        //IsGroundedCheck();
        Move();
        Animations();
    }
    private void Move()
    {
        if (stopPlayerMove)
        {
            playerMove_.x = 0;
            playerMove_.z = 0;
        }

        //Debug.Log(playerMove);

        /*playerMove.y = inWater ? 0f : playerGravity;// player not floating*/
        if (inWater)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }

        applyWalkSpeed = (inWater || playerCrouch_) ? walkSpeed / 2 : walkSpeed;
        applySprintSpeed = (inWater || playerCrouch_) ? sprintSpeed / 2 : sprintSpeed;

        Debug.Log($"applywalk : {applyWalkSpeed}, applysprint : {applySprintSpeed}");

        moveDirection = transform.TransformVector(playerMove_);

        if (playerSprint_)
        {
            movement = applySprintSpeed * Time.deltaTime * moveDirection;
            //Debug.Log($"sprint {rb.velocity}");
        }
        else
        {
            movement = applyWalkSpeed * Time.deltaTime * moveDirection;
            //Debug.Log($"walk {rb.velocity}");
        }
        currentPosition = transform.position;
        newPosition = currentPosition + movement;
        transform.position = newPosition;

        if (playerCrouch_)
        {
            // change height and offset
            capsuleCollider.height = crouchHeight;
            capsuleCollider.center = crouchCenter;
        }
        else
        {
            capsuleCollider.height = standHeight;
            capsuleCollider.center = standCenter;
        }
    }

    private void Jump()
    {
        Debug.Log($"Jump!");
        /*if (playerJump_ && isGrounded)
        {
            isGrounded = false;
            Jump();
        }*/
    }
    void IsGroundedCheck()
    {
        if (isGrounded)
        {
            return;
        }
        if (rb.velocity.y > 0)
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            Debug.Log($"hiting ground : {hit.transform.name}");
            if (hit.distance < rayLength)
            {
                isGrounded = true;
            }
        }
    }
    private void Animations()
    {
        intended = new Vector2(playerMove_.x, playerMove_.z);
        intended /= (playerSprint_ ? 1f : 2f);

        currentValue = new Vector2(animator.GetFloat("VelocityX"), animator.GetFloat("VelocityZ"));

        result = Vector2.Lerp(currentValue, intended, animationTransitionMultiplier * Time.deltaTime);

        animator.SetFloat("VelocityX", result.x);
        animator.SetFloat("VelocityZ", result.y);

        if (playerCrouch_ && !inWater)
        {
            animator.SetBool("Crouch", true);
            animator.SetFloat("VelocityX", playerMove_.x);
            animator.SetFloat("VelocityZ", playerMove_.z);
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
        if (playerJump_)
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
        facingDirection = Vector3.Cross(mainCamera.transform.right, Vector3.up);
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

    #region needToBeDone
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

    /*void Jump()
    {
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
    }*/

    #endregion
}
