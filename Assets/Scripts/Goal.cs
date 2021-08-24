using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string scene;
    public float threeStarTimeThreshold;
    public float twoStarTimeThreshold;

    private const string timerPath = "LevelCanvas/HUD/Timer";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("Level Beaten!!!");

            Timer timer = GameObject.Find(timerPath).GetComponent<Timer>();
            int starRanking = timer.m_fTimeSoFar <= threeStarTimeThreshold ? 3 : timer.m_fTimeSoFar <= twoStarTimeThreshold ? 2 : 1;
            SaveSystem.SaveLevel(SceneManager.GetActiveScene().name, timer.m_fTimeSoFar, starRanking);

            EndCondition.Win(this, scene);
        }
    }
}
