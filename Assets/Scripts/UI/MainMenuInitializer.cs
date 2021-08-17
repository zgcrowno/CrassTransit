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

        SaveData saveData = SaveSystem.LoadSaveData();
        List<string> saveNames = new List<string>();
        for (int i = 0; i < saveData.levelSaves.Length; i++)
        {
            saveNames.Add(saveData.levelSaves[i].name);
        }

        for (int i = 0; i < sceneCount; i++)
        {
            if (scenes[i].Contains("Menu"))
                continue;

            else
            {
                GameObject curButton = Instantiate(buttonPrefab, parent: this.transform);
                if (saveNames.Contains(scenes[i]))
                {
                    int idx = saveNames.IndexOf(scenes[i]);
                    curButton.GetComponent<LevelButton>().InitializeButton(scenes[i], true, saveData.levelSaves[idx].score);
                }
                else
                {
                    curButton.GetComponent<LevelButton>().InitializeButton(scenes[i], false, 0f);
                }
            }
        }
        
    }
}
