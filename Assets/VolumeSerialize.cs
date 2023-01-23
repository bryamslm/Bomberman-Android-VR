using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSerialize : MonoBehaviour
{
    GameInfo gameInfo;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        var dataFound =  LoadSystem.loadData<GameInfo>();

        if (dataFound != null)
        {
            gameInfo = dataFound;
            volumeSlider.value = gameInfo.volume;
       
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo);
        }

        volumeSlider.value = gameInfo.volume;
        
    }

    public void UpdateVolume(){
        gameInfo.volume = volumeSlider.value;
        LoadSystem.saveData<GameInfo>(gameInfo);
    }
}
