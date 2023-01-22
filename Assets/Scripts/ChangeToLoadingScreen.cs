using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Data;
using System;

public class ChangeToLoadingScreen : MonoBehaviour
{
    private string currentLevelName = "CurrentLevel";
    public int currentLevel;
    public TextAsset jsonFile;
    public LoadScene scriptLoad;

    void Start(){
        currentLevel = PlayerPrefs.GetInt(currentLevelName);
    }

    // private void OnDestroy()
    // {
    //     SaveData();
    // }

    // private void SaveData()
    // {
    //     PlayerPrefs.SetInt(currentLevelName, currentLevel+1);
    //     PlayerPrefs.Save();
    //     SavedData data = new SavedData(currentLevel+1);
    //     System.IO.File.WriteAllText(@".\Assets\Json files\SaveData.txt", JsonUtility.ToJson(data));
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            scriptLoad.nextLevel();
            SceneManager.LoadScene(2);
        }
    }
}
