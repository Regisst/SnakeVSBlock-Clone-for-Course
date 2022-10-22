using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";
    public void SaveLevel(int LevelIndex)
    {
        PlayerPrefs.SetInt(LevelIndexKey, LevelIndex);
    }
    public int GetLevelIndex()
    {
        return PlayerPrefs.GetInt(LevelIndexKey, 0);
    }
}
