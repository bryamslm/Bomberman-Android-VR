using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public int nextLevel;
    public Animator loadingScreenAnim;
    public float loadingTime = 1f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());
    }

    public void LoadNextLevel(int nextLevel){
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int nextLevelIndex){
        loadingScreenAnim.SetTrigger("Start");

        yield return new WaitForSeconds(loadingTime);
        
        SceneManager.LoadScene(nextLevelIndex);
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(3);
        LoadNextLevel(nextLevel);
    }
}
