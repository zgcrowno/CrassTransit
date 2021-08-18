using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndCondition
{
    private static string[] HeroSayings = new string[5] { 
        "BigProblem", 
        "DoAgain", 
        "NeverGoesWell", 
        "Painful", 
        "UhOh" 
    };
    private static GameObject controller;

   public static void Lose(MonoBehaviour instance)
    {
        Debug.Log("Lost game!");

        Time.timeScale = 0f;
        controller = GameObject.Find("PlayerController").gameObject;
        controller.SetActive(false);

        instance.StartCoroutine(ReloadScene());
    }

    public static void Win(string name)
    {
        Debug.Log("Won game!");
        SceneManager.LoadScene(name);
    }

    private static IEnumerator ReloadScene()
    {
        AudioSource source;
        yield return new WaitForSecondsRealtime(0.5f);
        try
        {
            source = Object.FindObjectOfType<AudioManager>().Play(HeroSayings[Random.Range(0, HeroSayings.Length)]);
            
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("The LoseCondition tried to play an audio clip but couldn't find the AudioManager in the scene. Either start from the MainMenu or add the AudioManager prefab to this scene.");
            throw;
        }
    
        yield return new WaitUntil(() => !source.isPlaying);
        Time.timeScale = 1f;
        controller.SetActive(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
