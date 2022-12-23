using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoMovement : MonoBehaviour
{
    [SerializeField] public MovementWithGaze script;
    // Start is called before the first frame update

    // Update is called once per frame
    public void OnPointerEnter()
    {
        script.move = true;
       
    }

    public void OnPointerExit()
    {
        script.move = false;
        
    }
}
