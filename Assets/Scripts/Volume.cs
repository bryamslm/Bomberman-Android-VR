using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    GameInfo gameInfo;
    [SerializeField] public GameObject pivote1;
    [SerializeField] public GameObject pivote2;
    [SerializeField] public GameObject gazePoint;
    [SerializeField] public Slider slider;
    [SerializeField] public AudioSource sound1;

    void Start()
    {
        var dataFound =  LoadSystem.loadData<GameInfo>();

        if (dataFound != null)
        {
            gameInfo = dataFound;
       
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo);
        }
        slider.value = gameInfo.volume;
        sound1.volume = slider.value;
    }

    void OnPointerClick()
    {
        float max;
        float current;
        Debug.Log(transform.parent.transform.name);
        if(transform.parent.transform.name == "music"){
            Debug.Log("Music");
            max = pivote1.transform.position.x - pivote2.transform.position.x;
            current = gazePoint.transform.position.x - pivote2.transform.position.x;
        }else
        {
            max = pivote1.transform.position.y - pivote2.transform.position.y;
            current = gazePoint.transform.position.y - pivote2.transform.position.y;

        }

        float volume = current / max;

        Debug.Log("Volumen: " + volume);
        
        slider.value = volume;
        sound1.volume = volume;
        gameInfo.volume = slider.value;
        LoadSystem.saveData<GameInfo>(gameInfo);

    }
}
