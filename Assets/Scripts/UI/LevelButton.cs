using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    private string levelName;
    private bool completed;
    private float bestTime;

    public void InitializeButton(string name, bool completed, float bestTime)
    {
        levelName = name;
        this.completed = completed;
        this.bestTime = bestTime;

        TextMeshProUGUI levelName_tmp = transform.Find("LevelName").GetComponent<TextMeshProUGUI>();
        levelName_tmp.text = levelName;

        if (this.completed)
        {
            TextMeshProUGUI levelCompleted_tmp = transform.Find("LevelCompleted").GetComponent<TextMeshProUGUI>();
            levelCompleted_tmp.text = "Complete";
            levelCompleted_tmp.color = Color.green;

            transform.Find("BestScore_Static").gameObject.SetActive(true);
            GameObject bestScore_go = transform.Find("BestScore_Dynamic").gameObject;
            bestScore_go.SetActive(true);
            bestScore_go.GetComponent<TextMeshProUGUI>().text = Stringify(this.bestTime);
        }

        else
        {
            // Prefab is set up to reflect an incomplete level
        }
    }

    public void GoToMyLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.levelName, LoadSceneMode.Single);
    }

    /// <summary>
    /// The given score should be in seconds. It will then convert to HH:MM:SS as a string
    /// </summary>
    public static string Stringify(float score)
    {
        int h = 0;
        int m = 0;

        while (score >= 3600f)
        {
            h++;
            score -= 3600f;
        }
        while (score >= 60f)
        {
            m++;
            score -= 60f;
        }

        string scoreString = "";

        //if (h < 10)
        //    scoreString += "0";
        //scoreString += (h + ":");

        if (m < 10)
            scoreString += "0";
        scoreString += (m + ":");

        if (score < 10f)
            scoreString += "0";
        scoreString += (score.ToString("F3"));

        return scoreString;
    }
}