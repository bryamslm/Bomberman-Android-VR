using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    //time 3:00
    public float  mins = 3;
    public float  secs = 60f;
    [SerializeField] public TextMeshProUGUI textMesh;
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
            secs = 60;
        }
        if (mins <= 0)
        {
            //game over
            Debug.Log("game over");
        }
        
        textMesh.text = "Time: " + mins + ":" + secsInt;
        
    }

    //metodo temporizador

}
