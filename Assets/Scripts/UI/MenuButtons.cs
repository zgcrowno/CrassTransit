using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    private GameObject controller;
    //private GameObject sceneEventSystem;

    public void Resume()
    {
        MenuManager.TogglePauseMenu();
    }

    public void ReturnToMain()
    {
        MenuManager.GoToMainMenu();
    }

    public void OpenCredits()
    {
        MenuManager.OpenCredits();
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
        if (!MenuManager.IsMenu())
        { 
            controller = GameObject.Find("PlayerController").gameObject;
            if (controller != null)
                controller.SetActive(false);

            //sceneEventSystem = GameObject.Find("EventSystem").gameObject;
            //if (sceneEventSystem != null)
            //    sceneEventSystem.SetActive(false);
        }
    }

    public void OnDisable()
    {
        if (!MenuManager.IsMenu())
        {
            Time.timeScale = 1f;

            if (controller != null)
                controller.SetActive(true);

            //if (sceneEventSystem != null)
            //    sceneEventSystem.SetActive(true);
        }
    }
}
