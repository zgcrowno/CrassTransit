using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string scene;

    private const string timerPath = "LevelCanvas/HUD/Timer";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("Level Beaten!!!");

            Timer timer = GameObject.Find(timerPath).GetComponent<Timer>();
            SaveSystem.SaveLevel(SceneManager.GetActiveScene().name, timer.m_fTimeSoFar);

            EndCondition.Win(scene);
        }
    }
}
