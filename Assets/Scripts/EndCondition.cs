using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndCondition
{
   public static void Lose()
    {
        Debug.Log("Lost game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Win()
    {
        Debug.Log("Won game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
