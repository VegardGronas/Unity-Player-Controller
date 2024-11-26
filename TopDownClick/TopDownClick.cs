using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownClick : MonoBehaviour
{
    [SerializeField]
    InputActionReference m_MoveAction;

    [SerializeField]
    TPCMove m_TPCMove;
    public TPCMove TPCMove => m_TPCMove;

    [SerializeField]
    TPCCamera m_TPCCamera;
    public TPCCamera TPCCamera => m_TPCCamera;

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    private void Start()
    {
        m_TPCCamera.transform.SetParent(null);
    }

    private void LateUpdate()
    {
        m_TPCCamera.transform.position = transform.position;
    }

    public void EnableInput()
    {
        m_MoveAction.action.performed += MoveInput;
    }
    public void DisableInput()
    {
        m_MoveAction.action.performed -= MoveInput;
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        m_TPCMove.Move();
    }
}