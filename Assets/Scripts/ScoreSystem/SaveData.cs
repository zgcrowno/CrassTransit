[System.Serializable]
public class SaveData
{
    public LevelSave[] levelSaves;

    public SaveData()
    {
        levelSaves = new LevelSave[0];
    }
}
