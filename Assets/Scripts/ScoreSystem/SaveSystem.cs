using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/SaveFile.save";

    public static void Save(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevel(string levelName, float levelScore, int starRanking)
    {
        LevelSave newLevelSave = new LevelSave(levelName, levelScore, starRanking);
        SaveData saveData = LoadSaveData();

        bool matchingLevel = false;
        for (int i = 0; i < saveData.levelSaves.Length; i++)
        {
            if (saveData.levelSaves[i].name == levelName)
            {
                //Overwrite old score for this level
                matchingLevel = true;
                if (newLevelSave.score < saveData.levelSaves[i].score)
                { 
                    saveData.levelSaves[i] = newLevelSave;
                }
            }
        }

        //No matching level so add new space to the saveData
        if (!matchingLevel)
        {
            LevelSave[] newLevelSaves = new LevelSave[saveData.levelSaves.Length + 1];
            saveData.levelSaves.CopyTo(newLevelSaves, 0);
            newLevelSaves[newLevelSaves.Length - 1] = newLevelSave;
            saveData.levelSaves = newLevelSaves;
        }

        //Write the new/updated SaveData to file
        Save(saveData);
    }

    public static SaveData LoadSaveData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Tried to load save data but could not find file. Using fresh.");
            return new SaveData();
        }
    }

    public static void WipeSave()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
