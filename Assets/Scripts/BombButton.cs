using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombButton : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private float bombTime  = 4f;
    [SerializeField] private AudioSource pipBomb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject gazePosition;
    private Vector3 rotation;
   
    void Awake()
    {
        bomb.SetActive(false);
        explosion.SetActive(false);
        rotation = bomb.transform.eulerAngles;
    }

    // Update is called once per frame
   
    public void PutBomb()
    {
        //duplicate bomb
        GameObject bomb_aux = Instantiate(bomb, bomb.transform.position, Quaternion.identity);
        
        //set bomb withuot parent
        bomb_aux.transform.SetParent(null);
        //set the scale
        
        //set the position
        bomb_aux.transform.position = new Vector3(gazePosition.transform.position.x, gazePosition.transform.position.y, gazePosition.transform.position.z);
        //bomb.transform.localScale = scaleLabyrind;
        bomb_aux.SetActive(true);
        //call the coroutine
        StartCoroutine(Wait(bomb_aux));
    }

    IEnumerator Wait(GameObject bomb_aux)
    {
        //play the sound
        pipBomb.Play(); 
        //wait for 3 seconds
        yield return new WaitForSeconds(bombTime);
        pipBomb.Stop();

        //set explosion position
        explosion.transform.position =new Vector3(bomb_aux.transform.position.x, 0.5f, bomb_aux.transform.position.z);
        //set active true
        explosion.SetActive(true);

        //Activate system particles in explosion
        explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();

        //get audio from explosion
        explosion.GetComponent<AudioSource>().Play();
        //set containerButtons as parent
        Destroy(bomb_aux);
        yield return new WaitForSeconds(1f);
        explosion.SetActive(false);

        
        
        
    }
}