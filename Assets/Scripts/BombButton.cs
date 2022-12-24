using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject labyrind;
    [SerializeField] private GameObject containerButtons;
    [SerializeField] private float bombTime  = 4f;
    [SerializeField] private AudioSource pipBomb;
    [SerializeField] private GameObject explosion;
    private Vector3 rotation;
   
    void Awake()
    {
        bomb.SetActive(false);
        explosion.SetActive(false);
        rotation = bomb.transform.eulerAngles;
    }

    // Update is called once per frame
   
    public void OnPointerClick()
    {
        explosion.SetActive(false);
        
        //set bomb withuot parent
        bomb.transform.SetParent(null);
        //set the scale
        //bomb.transform.localScale = scaleLabyrind;
        bomb.SetActive(true);
        //call the coroutine
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        //play the sound
        pipBomb.Play(); 
        //wait for 3 seconds
        yield return new WaitForSeconds(bombTime);
        pipBomb.Stop();

        //set explosion position
        explosion.transform.position = bomb.transform.position;
        //set active true
        explosion.SetActive(true);

        //Activate system particles in explosion
        explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();

        //get audio from explosion
        explosion.GetComponent<AudioSource>().Play();

        //set containerButtons as parent
        bomb.transform.SetParent(containerButtons.transform);
        //set the scale
        
        bomb.transform.position = transform.position;
        //set the rotation
        bomb.transform.eulerAngles = rotation;
        //set active false
        bomb.SetActive(false);
        
    }
}
