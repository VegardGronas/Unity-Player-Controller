using UnityEngine;

public class TPAnimations : MonoBehaviour
{
    [SerializeField]
    TPMove m_TPMove;

    [SerializeField]
    string moveBlendName = "StandardMoveblend";

    [SerializeField]
    Animator m_Animator;

    [SerializeField] float blendSpeed = 5f;

    private float currentBlend = 0;
    private float targetBlend = 0;

    private void Update()
    {
        if (m_TPMove.IsMoving)
        {
            if (m_TPMove.IsSprinting) targetBlend = 1;
            else targetBlend = .5f;
        }
        else targetBlend = 0;

        currentBlend = Mathf.Lerp(currentBlend, targetBlend, blendSpeed * Time.deltaTime);

        m_Animator.SetFloat(moveBlendName, currentBlend);
    }
}