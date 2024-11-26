using UnityEngine;

public class FirstPersonGameMode : BaseGameMode
{
    [SerializeField]
    FirstPerson m_FirstPerson;
    public FirstPerson FirstPerson => m_FirstPerson;

    private void Awake()
    {
        m_FirstPerson = Instantiate(m_FirstPerson, transform.position, transform.rotation);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void OnGamePaused()
    {
        Cursor.lockState = CursorLockMode.None;
        m_FirstPerson.DisableInput();
    }

    protected override void OnGameUnpaused()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_FirstPerson.EnableInput();
    }
}