using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    private float velocity;
    private string velocityName = "Velocity";
    private GameObject player;
    private GameObject velocityUpgrade;

    void Start()
    {
        player = GameObject.Find("Player");
        velocityUpgrade = GameObject.Find("VelocityUpgrade");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VelocityUp"))
        {
            velocity = player.GetComponent<Movement>().speed+1;
            player.GetComponent<Movement>().speed = velocity;

            PlayerPrefs.SetFloat(velocityName, velocity);
            PlayerPrefs.Save();

            Destroy(velocityUpgrade);
        }
    }
}
