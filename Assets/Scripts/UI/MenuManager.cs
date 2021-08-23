using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void TogglePauseMenu()
    {
        if (SceneManager.sceneCount > 1) //Pause menu must be open already
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
        else if (SceneManager.sceneCount == 1) //Pause menu closed
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
    }

    public static void GoToMainMenu()
    {
        if (SceneManager.sceneCount > 1) //Pause menu must be open
        { 
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static void OpenCredits()
    {
        if (SceneManager.sceneCount > 1) //Pause menu must be open
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
        SceneManager.LoadScene("CreditsMenu", LoadSceneMode.Single);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    public static bool IsMenu()
    {
        return (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "CreditsMenu");
    }
}
