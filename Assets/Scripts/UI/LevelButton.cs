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
            TextMeshPro levelCompleted_tmp = transform.Find("LevelCompleted").GetComponent<TextMeshPro>();
            levelCompleted_tmp.text = "Complete";
            levelCompleted_tmp.color = Color.green;

            transform.Find("BestScore_Static").gameObject.SetActive(true);
            GameObject bestScore_go = transform.Find("BestScore_Dynamic").gameObject;
            bestScore_go.SetActive(true);
            bestScore_go.GetComponent<TextMeshPro>().text = Stringify(this.bestTime);
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
        int s = 0;

        while (score >= 3600)
        {
            h++;
            score -= 3600;
        }
        while (score >= 60)
        {
            m++;
            score -= 60;
        }
        s = Mathf.FloorToInt(score);

        string scoreString = "";

        if (h < 10)
            scoreString += "0";
        scoreString += (h + ":");

        if (m < 10)
            scoreString += "0";
        scoreString += (m + ":");

        if (s < 10)
            scoreString += "0";
        scoreString += (s);

        return scoreString;
    }
}