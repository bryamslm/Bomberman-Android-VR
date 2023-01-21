using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLoadingScreen : MonoBehaviour
{
    private string currentLevelName = "CurrentLevel";
    public int currentLevel;

    void Start(){
        currentLevel = PlayerPrefs.GetInt(currentLevelName);
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(currentLevelName, currentLevel+1);
        PlayerPrefs.Save();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
