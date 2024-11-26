using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField]
    FPCamera m_FPCamera;
    public FPCamera FPCamera => m_FPCamera;

    [SerializeField]
    FPMove m_FPMove;
    public FPMove FPMove => m_FPMove;

    private void OnEnable()
    {
        EnableInput();
    }

    private void OnDisable()
    {
        DisableInput();
    }

    public void EnableInput() { }
    public void DisableInput() { }

    //Will be used with the new input system
    public void MoveInput() { }
    //Will be used with the new input system
    public void RotateCameraInput () { }
}