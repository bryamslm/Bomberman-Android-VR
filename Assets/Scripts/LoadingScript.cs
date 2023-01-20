using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScript : MonoBehaviour
{
    private int currentLevel;
    private string currentLevelName = "CurrentLevel";
    public TextMeshProUGUI levelText;

    // Update is called once per frame

    void Start(){
        levelText.text = "Level " + currentLevel;
        StartCoroutine(LoadLevel());
    }

    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        currentLevel = PlayerPrefs.GetInt(currentLevelName, 1) + 2;
    }

    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(currentLevel);
    }
}
