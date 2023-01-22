using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntry : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Load next level
        }
    }

}
