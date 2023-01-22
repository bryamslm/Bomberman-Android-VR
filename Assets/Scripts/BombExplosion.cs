using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] public GameObject inGameButtons;
    [SerializeField] public GameObject gameOverButtons;
    [SerializeField] public Movement movementScript;
    [SerializeField] public BombButton bombButtonScript;
    [SerializeField] public AudioSource gameAudio;
    [SerializeField] public AudioSource gameOverAudio;
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
            gameOverAudio.Play();
            gameAudio.Stop();
            inGameButtons.SetActive(false);
            gameOverButtons.SetActive(true);
            movementScript.enabled = false;
            bombButtonScript.enabled = false;
        }
        if (other.gameObject.CompareTag("pared"))
        {
            Debug.Log("pared Destroyed");
            //destroy player
            Destroy(other.gameObject);
        }
    }
}
