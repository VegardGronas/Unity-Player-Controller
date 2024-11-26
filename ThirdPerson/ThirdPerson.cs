using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPerson : MonoBehaviour
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
    TPCamera m_TPCamera;
    public TPCamera TPCamera => m_TPCamera;

    [SerializeField]
    TPMove m_TPMove;
    public TPMove TPMove => m_TPMove;

    private void Awake()
    {
        m_TPCamera.transform.SetParent(null);
    }

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void LateUpdate()
    {
        m_TPCamera.transform.position = transform.position;
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
        m_TPMove.Move(context.ReadValue<Vector2>());
    }
    public void LookInput(InputAction.CallbackContext context)
    {
        m_TPCamera.RotateCamera(context.ReadValue<Vector2>());
    }
    public void JumpInput(InputAction.CallbackContext context)
    {
        m_TPMove.Jump();
    }
    public void SprintInput(InputAction.CallbackContext context)
    {
        if (context.performed) m_TPMove.CurrentMoveSpeed = m_TPMove.SprintSpeed;
        else m_TPMove.CurrentMoveSpeed = m_TPMove.WalkSpeed;
    }
}