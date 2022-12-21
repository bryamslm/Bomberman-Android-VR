using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = null;
    // Start is called before the first frame update
    public void OnPointerEnter()
    {
        audioSource.Play();
    }

    public void OnPointerExit()
    {
        audioSource.Stop();
    }
}
