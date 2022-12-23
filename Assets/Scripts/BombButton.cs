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
    private Vector3 scaleBombSpace = new Vector3(0.270398527f,0.270398229f,0.270398319f);
    private Vector3 scaleLabyrind = new Vector3(0.150398527f,0.150398229f,0.150398319f);
    //Vector3(0.0939470902,0.375787586,0.0939470306)
    //Vector3(0.270398527,0.270398229,0.270398319)
    // Start is called before the first frame update

    void Awake()
    {
        bomb.SetActive(false);
        explosion.SetActive(false);
    }

    // Update is called once per frame
   
    public void OnPointerClick()
    {
        explosion.SetActive(false);
        //set labyrind as parent
        bomb.transform.SetParent(labyrind.transform);
        //set the scale
        bomb.transform.localScale = scaleLabyrind;
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
        bomb.transform.localScale = scaleBombSpace;
        //set the position of the bomb
        bomb.transform.position = transform.position;
        //set active false
        bomb.SetActive(false);
        
    }
}
