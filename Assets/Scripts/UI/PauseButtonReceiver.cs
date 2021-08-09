using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonReceiver : MonoBehaviour
{
    private Controls controls;

    void Awake()
    {
        controls = new Controls();

        controls.Gameplay.Pause.performed += ctx => PausePressed(ctx);
    }

    private void PausePressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        MenuManager.TogglePauseMenu();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
