using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] GameObject enemiesObject;
    [SerializeField] GameObject portal;
    [SerializeField] int enemiesQuantity;

    // Update is called once per frame
    void Update()
    {
        Transform[] enemies = enemiesObject.transform.GetComponentsInChildren<Transform>();
        enemiesQuantity = enemies.Length;
        Debug.Log("Enemies: " + enemiesQuantity);
        if(enemiesQuantity == 1){
            portal.SetActive(true);
        }
    }
}
