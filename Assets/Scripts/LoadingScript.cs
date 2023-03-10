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

    public GameInfo gameInfo;

    public const string path = "Data/BombermanRV";
    public const string fileName = "GameInfo";

    // Update is called once per frame

    void Start(){

        var dataFound = LoadSystem.loadData<GameInfo>(path, fileName);
        if (dataFound != null)
        {
            gameInfo = dataFound;

        
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo, path, fileName);
        }

        currentLevel = gameInfo.level;
<<<<<<< HEAD

        if(currentLevel == 8){
             levelText.text = "You Win!";
        }
        else
        {
            levelText.text = "Level " + gameInfo.level;
        }
        
=======
        levelText.text = "Level " + gameInfo.level;
>>>>>>> 56b9245 (ScreenShots for Readme)
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(6f);
        if(currentLevel == 8){
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene(currentLevel+2);
        }
    }
}
