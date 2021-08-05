using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameQuitter : MonoBehaviour
{
    private Keyboard kb;

    private void Awake()
    {
        kb = Keyboard.current;
    }

    void Update()
    {
        if (kb.escapeKey.wasPressedThisFrame)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
        }
    }
}
