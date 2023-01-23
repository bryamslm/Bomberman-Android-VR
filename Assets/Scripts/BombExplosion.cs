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

    public CameraPointerManager gazeScript;

    //on trigger enter
    void OnTriggerEnter(Collider other)
    {
   
        //if other is player
        if (other.gameObject.CompareTag("Enemie"))
        {

            //destroy player
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("userPostal"))
        {
      
            gameOverAudio.Play();
            gameAudio.Stop();
            inGameButtons.SetActive(false);
            gameOverButtons.SetActive(true);
            movementScript.enabled = false;
            bombButtonScript.enabled = false;
        }
        if (other.gameObject.CompareTag("pared"))
        {
    
            gazeScript.enabled = false;

            //destroy player
            Destroy(other.gameObject);

            gazeScript.enabled = true;
        }
    }
}
