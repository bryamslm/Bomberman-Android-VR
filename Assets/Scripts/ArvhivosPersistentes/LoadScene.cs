using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======
>>>>>>> 56b9245 (ScreenShots for Readme)

public class LoadScene : MonoBehaviour
{
    GameInfo gameInfo;
    public BoxCollider colliderExplosion;
    public Movement movementSpeed;
<<<<<<< HEAD
    public Slider volumeSlider;
=======
>>>>>>> 56b9245 (ScreenShots for Readme)

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
<<<<<<< HEAD
       
=======
            Debug.Log("Level a: " + gameInfo.level);
>>>>>>> 56b9245 (ScreenShots for Readme)
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo);
        }
<<<<<<< HEAD

        volumeSlider.value = gameInfo.volume;
        //get audio source
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = volumeSlider.value;
=======
>>>>>>> 56b9245 (ScreenShots for Readme)
    }

    public void nextLevel()
    {
        gameInfo.level += 1;
<<<<<<< HEAD
        gameInfo.volume = volumeSlider.value;
        if(applyRange){
            gameInfo.rangeExplosion += 0.25f;
=======
        if(applyRange){
            gameInfo.rangeExplosion += 0.2f;
>>>>>>> 56b9245 (ScreenShots for Readme)
        }
        if(apllySpeed){
            gameInfo.speed += 0.2f;
        }
        LoadSystem.saveData<GameInfo>(gameInfo);
<<<<<<< HEAD
 
=======
        Debug.Log("Level b: " + gameInfo.level);
>>>>>>> 56b9245 (ScreenShots for Readme)
    
    }

}
