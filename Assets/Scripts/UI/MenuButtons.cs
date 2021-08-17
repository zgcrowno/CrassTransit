using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    private GameObject controller;

    public void Resume()
    {
        MenuManager.TogglePauseMenu();
    }

    public void ReturnToMain()
    {
        MenuManager.GoToMainMenu();
    }

    public void QuitGame()
    {
        MenuManager.QuitGame();
    }

    public void WipeSave()
    {
        SaveSystem.WipeSave();
        MenuManager.GoToMainMenu();
    }

    public void OnEnable()
    {
        Time.timeScale = 0f;
        if (!MenuManager.IsMainMenu())
        { 
            controller = GameObject.Find("PlayerController").gameObject;
            controller.SetActive(false);
        }
    }

    public void OnDisable()
    {
        if (!MenuManager.IsMainMenu())
        { 
            Time.timeScale = 1f;
            controller.SetActive(true);
        }
    }
}
