using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeCurrentLevel : MonoBehaviour
{
    private int currentLevel = 1;
    private string currentLevelName = "CurrentLevel";

    private void onDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(currentLevelName, currentLevel);
        PlayerPrefs.Save();
    }
}
