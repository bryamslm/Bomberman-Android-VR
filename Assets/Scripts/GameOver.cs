using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnPointerClick(){
        if(transform.name == "irAlMenu")
            SceneManager.LoadScene(0);
        else if(transform.name == "playAgain")
        {
            //reload same scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
