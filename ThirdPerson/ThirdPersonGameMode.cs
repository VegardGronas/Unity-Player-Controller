using UnityEngine;

public class ThirdPersonGameMode : BaseGameMode
{
    [SerializeField]
    ThirdPerson m_ThirdPerson;
    public ThirdPerson ThirdPerson => m_ThirdPerson;

    private void Awake()
    {
        m_ThirdPerson = Instantiate(m_ThirdPerson, transform.position, transform.rotation);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void OnGamePaused()
    {
        Cursor.lockState = CursorLockMode.None;
        m_ThirdPerson.DisableInput();
    }

    protected override void OnGameUnpaused()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_ThirdPerson.EnableInput();
    }
}