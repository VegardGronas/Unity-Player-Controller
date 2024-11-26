using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TPCMove : MonoBehaviour
{
    [SerializeField]
    TPCCamera m_TPCCamera;

    private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    public void Move()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        Ray ray = m_TPCCamera.Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
        { 
            m_Agent.SetDestination(hit.point);  
        }
    }
}