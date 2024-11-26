using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPerson : MonoBehaviour
{
    [SerializeField]
    InputActionReference m_MoveAction;

    [SerializeField]
    InputActionReference m_SprintAction;

    [SerializeField]
    InputActionReference m_LookAction;

    [SerializeField]
    InputActionReference m_JumpAction;

    [SerializeField]
    FPCamera m_FPCamera;
    public FPCamera FPCamera => m_FPCamera;

    [SerializeField]
    FPMove m_FPMove;
    public FPMove FPMove => m_FPMove;

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void EnableInput() 
    {
        m_MoveAction.action.performed += MoveInput;
        m_MoveAction.action.canceled += MoveInput;

        m_LookAction.action.performed += LookInput;
        m_LookAction.action.canceled += LookInput;

        m_JumpAction.action.performed += JumpInput;

        m_SprintAction.action.performed += SprintInput;
        m_SprintAction.action.canceled += SprintInput;
    }
    public void DisableInput() 
    {
        m_MoveAction.action.performed -= MoveInput;
        m_MoveAction.action.canceled -= MoveInput;

        m_LookAction.action.performed -= LookInput;
        m_LookAction.action.canceled -= LookInput;

        m_JumpAction.action.performed -= JumpInput;

        m_SprintAction.action.performed -= SprintInput;
        m_SprintAction.action.canceled -= SprintInput;
    }

    public void MoveInput(InputAction.CallbackContext context) 
    {
        m_FPMove.Move(context.ReadValue<Vector2>());
    }
    public void LookInput (InputAction.CallbackContext context) 
    { 
        FPCamera.RotateCamera(context.ReadValue<Vector2>());
    }
    public void JumpInput(InputAction.CallbackContext context)
    {
        FPMove.Jump();
    }
    public void SprintInput(InputAction.CallbackContext context)
    {
        if(context.performed) FPMove.CurrentMoveSpeed = FPMove.SprintSpeed;
        else FPMove.CurrentMoveSpeed = FPMove.WalkSpeed;
    }
}