using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaController : MonoBehaviour
{
    public GameObject mapa;

    void OnPointerClick()
    {
        mapa.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        mapa.SetActive(false);

    }
}
