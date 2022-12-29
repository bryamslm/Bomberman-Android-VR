using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    //on trigger enter
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        //if other is player
        if (other.gameObject.CompareTag("Enemie"))
        {
            Debug.Log("Enemie Destroyed");
            //destroy player
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("userPostal"))
        {
            Debug.Log("You Lose");
            //destroy player
            //Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("pared"))
        {
            Debug.Log("pared Destroyed");
            //destroy player
            Destroy(other.gameObject);
        }
    }
}
