using UnityEngine;

public class TPAnimations : MonoBehaviour
{
    [SerializeField]
    TPMove m_TPMove;

    [SerializeField]
    string m_IsMovingAnimName = "IsMoving";

    [SerializeField]
    Animator m_Animator;

    private void Update()
    {
        m_Animator.SetBool(m_IsMovingAnimName, m_TPMove.IsMoving);
    }
}