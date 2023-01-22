using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerAbout : MonoBehaviour
{

    public Animator animator1;

    public void loadAkionAnimation()
    {
        animator1.SetBool("Enter", true);
    }
    public void loadBryamAnimation()
    { 
        animator1.SetBool("Enter", true);  
    }
    public void loadReynerAnimation()
    {
        animator1.SetBool("Enter", true);

    }

}
