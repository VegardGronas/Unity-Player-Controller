using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMove : BaseMovement
{
    protected override void NormalMove()
    {
        Vector3 forward = transform.forward * m_InputValue.y;
        Vector3 right = transform.right * m_InputValue.x;
        Vector3 targetMoveDirection = forward + right;
    
        m_CharacterController.Move(m_WalkSpeed * Time.deltaTime * targetMoveDirection);
    }

    protected override void SwimmingMove()
    {

    }

    protected override void ClimbingMove()
    {
        Vector3 up = transform.up * m_InputValue.y;
        Vector3 right = transform.right * m_InputValue.x;
        Vector3 targetMoveDirection = up + right;

        m_CharacterController.Move(m_WalkSpeed * Time.deltaTime * targetMoveDirection);
    }

    protected override void Gravity()
    {
        m_CharacterController.Move(-9f * Time.deltaTime * Vector3.up);
    }

    protected override void GlidingMove()
    {

    }
}