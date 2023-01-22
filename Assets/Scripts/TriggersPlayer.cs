using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersPlayer : MonoBehaviour
{
    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter mejora");
        //if other is player
        if (other.gameObject.name == "rangoMejora"){
            Debug.Log("rangoMejora");
            //destroy player
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "velocidadMejora"){
            Debug.Log("rangoMejora");
            //destroy player
            Destroy(other.gameObject);
        }
    }
}
