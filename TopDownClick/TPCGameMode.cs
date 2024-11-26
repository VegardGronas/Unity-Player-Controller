using UnityEngine;

public class TPCGameMode : BaseGameMode
{
    [SerializeField]
    TopDownClick m_TopDownClick;
    public TopDownClick TopDownClick => m_TopDownClick;

    private void Awake()
    {
        m_TopDownClick = Instantiate(m_TopDownClick, transform.position, transform.rotation);
    }

    protected override void OnGamePaused()
    {
        m_TopDownClick.DisableInput();
    }

    protected override void OnGameUnpaused()
    {
        m_TopDownClick.EnableInput();
    }
}