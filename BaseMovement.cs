using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BaseMovement : MonoBehaviour
{
    [SerializeField]
    protected MovementMove m_MovementMode;
    public MovementMove MovementMode {  get { return m_MovementMode; } set { m_MovementMode = value; } }

    [SerializeField]
    protected float m_WalkSpeed = 1;
    public float WalkSpeed { get { return m_WalkSpeed; } set { m_WalkSpeed = value; } }

    [SerializeField]
    protected float m_SprintSpeed = 2;
    public float SprintSpeed { get { return m_SprintSpeed; } set { m_SprintSpeed = value; } }

    protected CharacterController m_CharacterController;
    public CharacterController CharacterController => m_CharacterController;

    protected bool m_IsMoving;
    public bool IsMoving => m_IsMoving;

    protected Vector2 m_InputValue;

    protected virtual void Awake()
    {
        m_MovementMode = MovementMove.Normal;
    }

    protected virtual void Update()
    {
        if (!m_CharacterController.isGrounded) m_MovementMode = MovementMove.Falling;
        else m_MovementMode = MovementMove.Normal;

        m_IsMoving = m_InputValue.magnitude > 0.01f;

        switch (m_MovementMode)
        {
            case MovementMove.Normal:
                NormalMove();
                break;
            case MovementMove.Falling:
                Gravity();
                break;
            case MovementMove.Swimming:
                SwimmingMove();
                break;
            case MovementMove.Climbing:
                ClimbingMove();
                break;
            case MovementMove.Gliding:
                GlidingMove();
                break;
        }
    }

    public void Move(Vector2 inputValue)
    {
        m_InputValue = inputValue;
    }

    protected virtual void NormalMove() { }
    protected virtual void Gravity() { }
    protected virtual void SwimmingMove() { }
    protected virtual void ClimbingMove() { }
    protected virtual void GlidingMove() { }
}