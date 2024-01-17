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
    [SerializeField] private Vector3 ControllerStandCenter;
    [SerializeField] private Vector3 controllerCrouchCenter;


    public bool inWater;
    public bool stopPlayerMove;
    public bool canCrouch;
    private bool playerSprint_;
    private bool playerJump_;
    private bool isGrounded;


    [SerializeField] private float animationTransitionMultiplier = 10f;
    [SerializeField] private float jumpForce = -0.2f;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rayLength = 0.1f;
    [SerializeField] private float colliderStandHeight;
    [SerializeField] private float colliderCrouchHeight;
    private float applyWalkSpeed;
    private float applySprintSpeed;
    private int hitLayer;

    /* // IK
     [SerializeField] private Transform rightToHold;
     [SerializeField] private Transform leftToHold;
     float positionweight = 0f;*/


    private void OnEnable()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

        inputActions.Player.Crouch.started += GetCrouchValues;
        inputActions.Player.Crouch.performed += GetCrouchValues;
        inputActions.Player.Crouch.canceled += GetCrouchValues;
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
    }

    private void GetCrouchValues(InputAction.CallbackContext context)
    {
        //Debug.Log($"{context}");
        if (context.performed)
        {
            canCrouch = !canCrouch;
            Debug.Log($"{canCrouch}");
        }
    }

    private void Update()
    {
        IsGroundedCheck();
        Move();
        Crouch();
        Jump();
        Animations();
    }

    private void Move()
    {
        if (stopPlayerMove)
        {
            playerMove_.x = 0;
            playerMove_.z = 0;
        }

        if (inWater)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }

        applyWalkSpeed = (inWater || canCrouch) ? walkSpeed / 2 : walkSpeed;

        if (inWater && !canCrouch)
        {
            applySprintSpeed = sprintSpeed / 2;
        }
        else if (canCrouch && !inWater)
        {
            applySprintSpeed = walkSpeed / 2;
        }
        else
        {
            applySprintSpeed = sprintSpeed;
        }

        //Debug.Log($"applywalk : {applyWalkSpeed}, applysprint : {applySprintSpeed}");

        moveDirection = transform.TransformVector(playerMove_);

        if (playerSprint_)
        {
            movement = applySprintSpeed * Time.deltaTime * moveDirection;
        }
        else
        {
            movement = applyWalkSpeed * Time.deltaTime * moveDirection;
        }
        currentPosition = transform.position;
        newPosition = currentPosition + movement;
        transform.position = newPosition;
    }

    private void Crouch()
    {
        if (hitLayer == 11)
        {
            canCrouch = true;
        }
        /* else
         {
             canCrouch = false;
         }*/

        if (canCrouch)
        {
            // change height and offset
            capsuleCollider.height = colliderCrouchHeight;
            capsuleCollider.center = controllerCrouchCenter;
        }
        else
        {
            capsuleCollider.height = colliderStandHeight;
            capsuleCollider.center = ControllerStandCenter;
        }

    }
    private void Jump()
    {
        //Debug.Log($"Y : {playerMove_.y} rb : {rb.velocity.y}");
        if (playerJump_ && isGrounded)
        {
            // jump
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    void IsGroundedCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            //Debug.Log($"hiting ground : {hit.transform.name}");

            hitLayer = hit.transform.gameObject.layer;
            Debug.Log($"Layer : {hitLayer}");

            if (hit.distance < rayLength)
            {
                isGrounded = true;
                //Debug.Log($"IGT {isGrounded}");
            }
            else
            {
                isGrounded = false;
                //Debug.Log($"IGF {isGrounded}");
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

        if (canCrouch && !inWater)
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

        /*if (playerJump_)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }*/
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

        inputActions.Player.Crouch.started -= GetCrouchValues;
        inputActions.Player.Crouch.performed -= GetCrouchValues;
        inputActions.Player.Crouch.canceled -= GetCrouchValues;
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
