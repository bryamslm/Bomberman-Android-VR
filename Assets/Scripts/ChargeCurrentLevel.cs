using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeCurrentLevel : MonoBehaviour
{
    private int currentLevel;
    private string currentLevelName = "CurrentLevel";

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

        
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(currentLevelName, currentLevel);
        PlayerPrefs.Save();
    }
}
