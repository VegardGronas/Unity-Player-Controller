using UnityEngine;
using UnityEngine.InputSystem;


public class BaseGameMode : MonoBehaviour
{
    [SerializeField]
    InputActionReference m_PauseAction;

    [SerializeField]
    protected bool m_GamePaused;
    public bool GamePaused => m_GamePaused;

    protected virtual void OnEnable()
    {
        m_PauseAction.action.performed += PauseInput;
    }

    protected virtual void OnDisable()
    {
        m_PauseAction.action.performed -= PauseInput;
    }

    protected void PauseInput(InputAction.CallbackContext context)
    {
        m_GamePaused = !m_GamePaused;

        if (m_GamePaused) OnGamePaused();
        else OnGameUnpaused();
    }

    public void SetPauseGameState(bool paused)
    {
        m_GamePaused = paused;

        if (m_GamePaused) OnGamePaused();
        else OnGameUnpaused();
    }

    protected virtual void OnGamePaused() { }
    protected virtual void OnGameUnpaused() { }
}