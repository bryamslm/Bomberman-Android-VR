using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Movement movement;
    [SerializeField] private TimeController timeController;
    void OnPointerClick(){
        if(transform.name == "Pause"){
            inGameMenu.SetActive(false);
            pauseMenu.SetActive(true);
            movement.enabled = false;
            timeController.timeWait = true;
        }
        else if(transform.name == "continue"){
            inGameMenu.SetActive(true);
            pauseMenu.SetActive(false);
            movement.enabled = true;
            timeController.timeWait = false;
        }
    }
}
