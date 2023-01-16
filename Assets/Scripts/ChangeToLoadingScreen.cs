using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLoadingScreen : MonoBehaviour
{
    public int nextLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
