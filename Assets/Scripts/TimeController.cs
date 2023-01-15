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
    [SerializeField] public GameObject inGameButtons;
    [SerializeField] public GameObject gameOverButtons;
    [SerializeField] public Movement movementScript;
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
        //resta a secs el tiempo que pasa
        secs -= Time.deltaTime;

        int secsInt = (int)secs;
        
        if (secs <= 0)
        {
            mins -= 1;
            if(mins != 0)
                secs = 60;
        }

        if(printTime)
        {
            if(secsInt >9)
                textMesh.text = "Time: " + mins + ":" + secsInt;
            else
                textMesh.text = "Time: " + mins + ":0" + secsInt;
        }
            

        if (mins <= 0f && secsInt <= 0)
        {
            //game over
            Debug.Log("game over");
            gameOverAudio.Play();
            gameAudio.Stop();
            
            printTime = false;
            inGameButtons.SetActive(false);
            gameOverButtons.SetActive(true);
            movementScript.enabled = false;
        }

        
        
    }

    //metodo temporizador

}
