using UnityEngine;

public class TPCCamera : MonoBehaviour
{
    [SerializeField]
    Camera m_Camera;
    public Camera Camera => m_Camera;

    private void Start()
    {
        if (Camera.main != null && Camera.main != m_Camera)
        {
            Destroy(Camera.main.gameObject);
        }
    }
}