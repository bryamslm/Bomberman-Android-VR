using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    GameInfo gameInfo;
    public BoxCollider colliderExplosion;
    public Movement movementSpeed;
    public Slider volumeSlider;

    public bool apllySpeed = false;
    public bool applyRange = false;

    public void Start()
    {
        var dataFound =  LoadSystem.loadData<GameInfo>();

        if (dataFound != null)
        {
            gameInfo = dataFound;
            movementSpeed.speed = gameInfo.speed;
            colliderExplosion.size = new Vector3(gameInfo.rangeExplosion, colliderExplosion.size.y, gameInfo.rangeExplosion);
       
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo);
        }

        volumeSlider.value = gameInfo.volume;
        //get audio source
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = volumeSlider.value;
    }

    public void nextLevel()
    {
        gameInfo.level += 1;
        gameInfo.volume = volumeSlider.value;
        if(applyRange){
            gameInfo.rangeExplosion += 0.25f;
        }
        if(apllySpeed){
            gameInfo.speed += 0.2f;
        }
        LoadSystem.saveData<GameInfo>(gameInfo);
 
    
    }

}
