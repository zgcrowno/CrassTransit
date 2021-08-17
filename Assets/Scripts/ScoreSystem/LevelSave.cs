using UnityEngine;

[System.Serializable]
public struct LevelSave
{
    public string name;
    public float score;

    public LevelSave(string name, float score)
    {
        this.name = name;
        this.score = score;
    }

    public LevelSave(string name)
    {
        this.name = name;
        this.score = Mathf.Infinity;
    }
}
