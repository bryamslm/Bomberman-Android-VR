using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutVolume : MonoBehaviour
{
    GameInfo gameInfo;
    // Start is called before the first frame update
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

        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = gameInfo.volume;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
