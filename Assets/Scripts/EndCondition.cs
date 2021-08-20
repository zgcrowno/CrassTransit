using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EndCondition
{
    private static string[] HeroLossSayings = new string[11] { 
        "BigProblem",
        "BlindSided",
        "CrazyStuff",
        "DoAgain",
        "FreakOut",
        "NeverGoesWell",
        "NotMyThing",
        "Ohhhh",
        "Painful",
        "UhOh",
        "What"
    };
    private static string[] HeroWinSayings = new string[1]
    {
        "ThanksWasFun"
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

    public static void Win(MonoBehaviour instance, string name)
    {
        Debug.Log("Won game!");

        Time.timeScale = 0f;
        controller = GameObject.Find("PlayerController").gameObject;
        controller.SetActive(false);

        instance.StartCoroutine(LoadNextScene(name));
    }

    private static IEnumerator ReloadScene()
    {
        AudioSource source;
        yield return new WaitForSecondsRealtime(0.5f);
        try
        {
            source = Object.FindObjectOfType<AudioManager>().Play(HeroLossSayings[Random.Range(0, HeroLossSayings.Length)]);
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("The LoseCondition tried to play an audio clip but couldn't find the AudioManager in the scene. Either start from the MainMenu or add the AudioManager prefab to this scene.");
            throw;
        }
    
        yield return new WaitUntil(() => !source.isPlaying);
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 1f;
        controller.SetActive(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private static IEnumerator LoadNextScene(string name)
    {
        AudioSource source;
        yield return new WaitForSecondsRealtime(0.25f);
        try
        {
            source = Object.FindObjectOfType<AudioManager>().Play(HeroWinSayings[Random.Range(0, HeroWinSayings.Length)]);
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("The WinCondition tried to play an audio clip but couldn't find the AudioManager in the scene. Either start from the MainMenu or add the AudioManager prefab to this scene.");
            throw;
        }

        yield return new WaitUntil(() => !source.isPlaying);
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 1f;
        controller.SetActive(true);

        SceneManager.LoadScene(name);
    }
}
