using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public int nextLevel;
    public Animator loadingScreenAnim;
    public float loadingTime = 1f;
    public GameObject minimap;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            minimap.SetActive(false);
            LoadNextLevel(nextLevel);
        }
    }

    public void LoadNextLevel(int nextLevel){
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int nextLevelIndex){
        loadingScreenAnim.SetTrigger("Start");

        yield return new WaitForSeconds(loadingTime);
        
        SceneManager.LoadScene(nextLevelIndex);
    }
}
