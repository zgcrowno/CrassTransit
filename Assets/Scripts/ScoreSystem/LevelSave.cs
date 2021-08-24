using UnityEngine;

[System.Serializable]
public struct LevelSave
{
    public string name;
    public float score;
    public int starRanking;

    public LevelSave(string name, float score, int starRanking)
    {
        this.name = name;
        this.score = score;
        this.starRanking = starRanking;
    }

    public LevelSave(string name)
    {
        this.name = name;
        this.score = Mathf.Infinity;
        this.starRanking = 1;
    }
}
