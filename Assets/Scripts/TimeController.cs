using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    //time 3:00
    public float  mins;
    public float  secs;
    private bool printTime = true;
    public bool timeWait = false;
    [SerializeField] public GameObject inGameButtons;
    [SerializeField] public GameObject gameOverButtons;
    [SerializeField] public Movement movementScript;
    [SerializeField] public BombButton bombButtonScript;
    [SerializeField] public TextMeshProUGUI textMesh;
    [SerializeField] public AudioSource gameAudio;
    [SerializeField] public AudioSource gameOverAudio;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        Debug.Log(textMesh);

        
    }


    // Update is called once per frame
    void Update()
    {
       if(!timeWait){
            //resta a secs el tiempo que pasa
            secs -= Time.deltaTime;

            int secsInt = (int)secs;
            
            if (secs <= 0)
            {
                mins -= 1;
                if(mins >= 0)
                    secs = 60;
            }

            if(printTime)
            {
                if(secsInt >9)
                    textMesh.text = "Time: " + mins + ":" + secsInt;
                else
                    textMesh.text = "Time: " + mins + ":0" + secsInt;
            }
            
            int secsAux = (int)secs;

            if (mins <= 0f && secsAux <= 0)
            {
                //game over
                Debug.Log("game over");
                 textMesh.text = "Time: " + "0:00";
                gameOverAudio.Play();
                gameAudio.Stop();
                
                printTime = false;
                inGameButtons.SetActive(false);
                gameOverButtons.SetActive(true);
                movementScript.enabled = false;
                bombButtonScript.enabled = false;
            }
       }

        
    }

    //metodo temporizador

}
