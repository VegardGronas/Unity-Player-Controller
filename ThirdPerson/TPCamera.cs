using UnityEngine;

public class TPCamera : MonoBehaviour
{
    [SerializeField]
    Camera m_Camera;
    public Camera Camera => m_Camera;

    [SerializeField]
    Transform m_CameraSlot;

    [SerializeField]
    Transform m_YawTransform;
    public Transform YawTransform => m_YawTransform;

    [SerializeField]
    Transform m_PitchTransform;
    public Transform PitchTransform => m_PitchTransform;

    [SerializeField]
    bool m_InvertPitch = true;

    [SerializeField]
    float m_HorizontalSensitivity = 1;

    [SerializeField]
    float m_VerticalSensitivity = 1;

    float m_CurrentYawValue = 0;

    float m_CurrentPitchValue = 0;
    [SerializeField]
    float m_PitchMinClampedValue = -90f;
    [SerializeField]
    float m_PitchMaxClampedValue = 90f;

    private Vector2 m_InputValue;

    private void Start()
    {
        if (Camera.main != null && Camera.main != m_Camera)
        {
            Destroy(Camera.main.gameObject);
        }
    }

    public void RotateCamera(Vector2 InputValue)
    {
        m_InputValue = InputValue;

        if (m_InvertPitch) m_CurrentPitchValue -= InputValue.y * m_VerticalSensitivity;
        else m_CurrentPitchValue += InputValue.y * m_VerticalSensitivity;

        m_CurrentPitchValue = Mathf.Clamp(m_CurrentPitchValue, m_PitchMinClampedValue, m_PitchMaxClampedValue);

        m_CurrentYawValue += InputValue.x * m_HorizontalSensitivity;
    }

    private void Update()
    {
        if (m_InputValue.magnitude > 0.01f)
        {
            m_YawTransform.rotation = Quaternion.Euler(0, m_CurrentYawValue, 0);
            m_PitchTransform.localRotation = Quaternion.Euler(m_CurrentPitchValue, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        CameraCollision();
    }

    private void CameraCollision()
    {
        Vector3 rayStart = transform.position;
        Vector3 rayDirection = (m_CameraSlot.position - rayStart).normalized;
        float distance = Vector3.Distance(rayStart, m_CameraSlot.position);

        RaycastHit hit;

        if(Physics.Raycast(rayStart, rayDirection, out hit, distance))
        {
            m_Camera.transform.position = hit.point;
        }
        else
        {
            m_Camera.transform.localPosition = Vector3.zero;
        }
    }
}