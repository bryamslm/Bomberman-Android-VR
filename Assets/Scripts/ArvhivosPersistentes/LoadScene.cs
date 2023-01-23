using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    GameInfo gameInfo;
    public BoxCollider colliderExplosion;
    public Movement movementSpeed;

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
    }

    public void nextLevel()
    {
        gameInfo.level += 1;
        if(applyRange){
            gameInfo.rangeExplosion += 0.25f;
        }
        if(apllySpeed){
            gameInfo.speed += 0.2f;
        }
        LoadSystem.saveData<GameInfo>(gameInfo);
 
    
    }

}
