using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public int nextLevel = 3;

    // Update is called once per frame

    void Start(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        yield return new WaitForSeconds(6f);
        
        SceneManager.LoadScene(nextLevel);
    }
}
