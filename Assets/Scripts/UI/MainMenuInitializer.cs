using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInitializer : MonoBehaviour
{
    public GameObject buttonPrefab;
    int sceneCount;
    string[] scenes;
    void Awake()
    {
        sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }

        for (int i = 0; i < sceneCount; i++)
        {
            if (scenes[i].Contains("Menu"))
                continue;

            else
            {
                GameObject curButton = Instantiate(buttonPrefab, parent: this.transform);
                curButton.GetComponent<LevelButton>().InitializeButton(scenes[i], false, 0f);
            }
        }
        
    }
}
