using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInputs inputActions;
    private Vector3 playerMove_;
    private bool playerSprint_;
    private bool playerJump_;
    public bool canCrouch;

    private void OnEnable()
    {
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
        if (context.performed)
        {
            playerJump_ = context.ReadValueAsButton();
            //Debug.Log($"jumped");
        }
    }
    private void GetCrouchValues(InputAction.CallbackContext context)
    {
        //Debug.Log($"{context}");
        if (context.performed)
        {
            canCrouch = !canCrouch;
            //Debug.Log($"{canCrouch}");
        }
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
}
