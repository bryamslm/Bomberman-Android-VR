using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInfo
{
    public int level;
    public float speed;
    public float rangeExplosion;

    public GameInfo(int level, float speed, float rangeExplosion)
    {
        this.level = level;
        this.speed = speed;
        this.rangeExplosion = rangeExplosion;
    }

    
}
