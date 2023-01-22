using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersPlayer : MonoBehaviour
{
    public LoadScene scriptLoad;

    [SerializeField] public GameObject inGameButtons;
    [SerializeField] public GameObject gameOverButtons;
    [SerializeField] public Movement movementScript;
    [SerializeField] public BombButton bombButtonScript;
    [SerializeField] public AudioSource gameAudio;
    [SerializeField] public AudioSource gameOverAudio;

    // OnTriggerEnter is called when the Collider other enters the trigger
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter mejora");
        //if other is player
        if (other.gameObject.name == "rangoMejora"){
            Debug.Log("rangoMejora");

            scriptLoad.applyRange = true;
                     //destroy player
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "velocidadMejora"){
            Debug.Log("rangoMejora");
            scriptLoad.apllySpeed = true;
            //destroy player
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemie")){
            Debug.Log("You Lose");
            gameOverAudio.Play();
            gameAudio.Stop();
            inGameButtons.SetActive(false);
            gameOverButtons.SetActive(true);
            movementScript.enabled = false;
            bombButtonScript.enabled = false;
        }

       
    }
}
