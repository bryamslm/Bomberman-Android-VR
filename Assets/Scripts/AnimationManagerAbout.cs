using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerAbout : MonoBehaviour
{

    public Animator animator1;
    public AudioSource audioSource;

    public IEnumerator loadAkionAnimation()
    {
        animator1.SetBool("Enter", true);
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        animator1.SetBool("Enter", false);
    }
    public IEnumerator loadBryamAnimation()
    { 
        animator1.SetBool("Enter", true); 
        audioSource.Play(); 
        yield return new WaitForSeconds(1.5f);
        animator1.SetBool("Enter", false);
    }
    public IEnumerator loadReynerAnimation()
    {
        animator1.SetBool("Enter", true);
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        animator1.SetBool("Enter", false);

    }

}
