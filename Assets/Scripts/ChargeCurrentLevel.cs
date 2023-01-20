using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCurrentLevel : MonoBehaviour
{
    private int currentLevel = 1;
    private string currentLevelName = "CurrentLevel";

    private void Awake()
    {
        LoadData();
    }

    private void onDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(currentLevelName, currentLevel);
    }

    private void LoadData()
    {
        PlayerPrefs.GetInt(currentLevelName, 1);
    }
}
