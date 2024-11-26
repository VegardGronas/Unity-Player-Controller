using UnityEngine;

public class TPMove : BaseMovement
{
    [SerializeField]
    TPCamera m_TPCamera;

    protected override void Update()
    {
        ///Have to performe the gravcity before the base, in order for the charactercontroller to correcly check if grounded.
        Gravity();

        m_VerticalVelocityFactor = Mathf.Lerp(m_VerticalVelocityFactor, m_GravityValue, m_AirTimeDampner * Time.deltaTime);

        base.Update();
    }

    protected override void NormalMove()
    {
        Vector3 forward = m_TPCamera.YawTransform.forward * m_InputValue.y;
        Vector3 right = m_TPCamera.YawTransform.right * m_InputValue.x;
        Vector3 targetMoveDirection = forward + right;

        Quaternion lookRotation = Quaternion.LookRotation(targetMoveDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 15f * Time.deltaTime);

        m_CharacterController.Move(m_CurrentMoveSpeed * Time.deltaTime * targetMoveDirection);
    }

    public override void Jump()
    {
        m_VerticalVelocityFactor = m_JumpStrength;
    }

    protected override void SwimmingMove()
    {

    }

    /// <summary>
    /// Currently some placeholder values in here.
    /// </summary>
    protected override void ClimbingMove()
    {
        Vector3 up = transform.up * m_InputValue.y;
        Vector3 right = transform.right * m_InputValue.x;
        Vector3 targetMoveDirection = up + right;

        m_CharacterController.Move(m_WalkSpeed * Time.deltaTime * targetMoveDirection);
    }

    protected override void Gravity()
    {
        m_CharacterController.Move(m_VerticalVelocityFactor * Time.deltaTime * Vector3.up);
    }

    protected override void GlidingMove()
    {

    }
}
