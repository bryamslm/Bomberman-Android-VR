using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScript : MonoBehaviour
{
    public int currentLevel;
    private string currentLevelName;
    public TextMeshProUGUI levelText;

    // Update is called once per frame

    void Start(){
        currentLevel = PlayerPrefs.GetInt(currentLevelName, 1);
        levelText.text = "Level " + currentLevel;
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(currentLevel+2);
    }
}
