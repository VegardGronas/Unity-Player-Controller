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
    protected float m_GravityValue = -9.3f;
    public float GravityValue => m_GravityValue;

    [SerializeField]
    protected float m_JumpStrength = 10f;

    [SerializeField]
    protected float m_AirTimeDampner = 10f;

    protected float m_VerticalVelocityFactor = 0;

    [SerializeField]
    protected float m_WalkSpeed = 5f;
    public float WalkSpeed { get { return m_WalkSpeed; } set { m_WalkSpeed = value; } }

    [SerializeField]
    protected float m_SprintSpeed = 8f;
    public float SprintSpeed { get { return m_SprintSpeed; } set { m_SprintSpeed = value; } }

    [SerializeField]
    protected float m_CurrentMoveSpeed;
    public float CurrentMoveSpeed { get { return m_CurrentMoveSpeed; } set { m_CurrentMoveSpeed = value; } }

    protected CharacterController m_CharacterController;
    public CharacterController CharacterController => m_CharacterController;

    protected bool m_IsMoving;
    public bool IsMoving => m_IsMoving;

    [SerializeField]
    protected bool m_IsGrounded;
    public bool IsGrounded => m_IsGrounded;

    protected Vector2 m_InputValue;

    protected virtual void Awake()
    {
        m_CurrentMoveSpeed = m_WalkSpeed;
        m_VerticalVelocityFactor = m_GravityValue;
        m_MovementMode = MovementMove.Normal;
        m_CharacterController = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {
        m_IsGrounded = m_CharacterController.isGrounded;

        m_IsMoving = m_InputValue.magnitude > 0.01f;

        switch (m_MovementMode)
        {
            case MovementMove.Normal:
                NormalMove();
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

    public virtual void Jump() { }
    protected virtual void NormalMove() { }
    protected virtual void Gravity() { }
    protected virtual void SwimmingMove() { }
    protected virtual void ClimbingMove() { }
    protected virtual void GlidingMove() { }
}