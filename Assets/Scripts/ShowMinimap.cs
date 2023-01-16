using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMinimap : MonoBehaviour
{
    public GameObject minimap;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMinimapCo());
    }

    IEnumerator ShowMinimapCo(){
        yield return new WaitForSeconds(4.5f);
        minimap.SetActive(true);
    }
}
