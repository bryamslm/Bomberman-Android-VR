using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class ChargeCurrentLevel : MonoBehaviour
{
    private int currentLevel;
    private string currentLevelName = "CurrentLevel";
    public TextAsset jsonFile;

    void Start()
    {
        LoadData();
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void LoadData()
    {
        SavedData data = JsonUtility.FromJson<SavedData>(jsonFile.text);
        currentLevel = data.currentLevel;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(currentLevelName, currentLevel);
        PlayerPrefs.Save();
    }
}
