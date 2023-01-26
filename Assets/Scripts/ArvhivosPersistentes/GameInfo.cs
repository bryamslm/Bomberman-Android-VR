using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInfo
{
    public int level;
    public float speed;
    public float rangeExplosion;
<<<<<<< HEAD
    public float volume;

    public GameInfo(int level, float speed, float rangeExplosion, float volume=1f)
=======

    public GameInfo(int level, float speed, float rangeExplosion)
>>>>>>> 56b9245 (ScreenShots for Readme)
    {
        this.level = level;
        this.speed = speed;
        this.rangeExplosion = rangeExplosion;
<<<<<<< HEAD
        this.volume = volume;
=======
>>>>>>> 56b9245 (ScreenShots for Readme)
    }

    
}
