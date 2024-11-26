using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TPCMove : MonoBehaviour
{
    [SerializeField]
    TPCCamera m_TPCCamera;

    private NavMeshAgent m_Agent;

    [SerializeField]
    GameObject m_ClickVisualiserPrefab;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        m_ClickVisualiserPrefab = Instantiate(m_ClickVisualiserPrefab);
        m_ClickVisualiserPrefab.SetActive(false);
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

            m_ClickVisualiserPrefab.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(DisableClickVisualiser());

            m_ClickVisualiserPrefab.transform.position = hit.point;
        }
    }

    private IEnumerator DisableClickVisualiser()
    {
        yield return new WaitForSeconds(1);

        m_ClickVisualiserPrefab.SetActive(false);
    }
}