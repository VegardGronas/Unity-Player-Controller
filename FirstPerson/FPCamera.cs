using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    [SerializeField]
    Camera m_Camera;
    public Camera Camera => m_Camera;

    [SerializeField]
    Transform m_YawTransform;

    [SerializeField]
    Transform m_PitchTransform;

    [SerializeField]
    float m_HorizontalSensitivity = 1;

    [SerializeField]
    float m_VerticalSensitivity = 1;

    float m_CurrentYawValue= 0;

    float m_CurrentPitchValue = 0;
    [SerializeField]
    float m_PitchMinClampedValue = -90f;
    [SerializeField]
    float m_PitchMaxClampedValue = 90f;

    private Vector2 m_InputValue;

    public void RotateCamera(Vector2 InputValue) 
    { 
        m_InputValue = InputValue;

        m_CurrentPitchValue += InputValue.y * m_VerticalSensitivity;
        
        m_CurrentPitchValue = Mathf.Clamp(m_CurrentPitchValue, m_PitchMinClampedValue, m_PitchMaxClampedValue);

        m_CurrentYawValue += InputValue.x * m_HorizontalSensitivity;
    }

    private void Update()
    {
        if(m_InputValue.magnitude > 0.01f)
        {
            m_YawTransform.rotation = Quaternion.Euler(0, m_CurrentYawValue, 0);
            m_PitchTransform.localRotation = Quaternion.Euler(m_CurrentPitchValue, 0, 0);    
        }
    }
}