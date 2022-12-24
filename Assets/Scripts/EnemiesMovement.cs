using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    public float velMov = 0.5f, velRot = 90f;

    public float timeReaction = 2f;
    public float dist = 0.2f;
    float rotation = 0;
    bool rot = false;
    bool walk = true;
    Vector3 antPosition;
    bool antRotation;

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //draw big ray
        Debug.DrawRay(transform.position, transform.forward * dist, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, dist))
        {
            
            if (hit.collider && walk == true)
            {
                walk = false;
                StartCoroutine(Rotate());
            }
        }

        //transform.Translate(Vector3.forward * velMov * Time.deltaTime);
        if(walk)
        {
            transform.position += (transform.forward * velMov * Time.deltaTime);
        }

        // if(rot)
        // {
        //     //sume 90 degrees to the rotation 
        //     //get rotation
        //     float auxRotation = transform.rotation.eulerAngles.y;
        //     auxRotation += 1;
        //     //set rotation
        //     transform.transform.eulerAngles = new Vector3(0, auxRotation, 0);
        //     //Vector3(0,287.999756,0)
        //     //Vector3(0,270,0)
        //     //Quaternion(0,0.707106829,0,-0.707106829)
        //     Debug.Log("rotation: " + transform.rotation.eulerAngles);

        //     auxRotation = transform.rotation.eulerAngles.y; 

        // }
    }

    IEnumerator Rotate()
    {
        //random 1 or 2
        int random = Random.Range(1, 3);

        //Debug.Log("random: " + random);

        //Debug.Log("position: " + transform.position + " - ant position: " + antPosition + " ant rotation: " + antRotation);

        if(random == 1 && transform.position.z == antPosition.z && antRotation == false)
        {
           // Debug.Log("If 1");
            random = 2;
        }
        else if(random == 2 && transform.position.z == antPosition.z && antRotation == true)
        {
            //Debug.Log("If 2");
            random = 1;
        }
        

        //if 1 sume 90 degrees
        if(random == 1)
        {
            antRotation = true;
            rotation = transform.rotation.eulerAngles.y;
            rotation += 90;
            if(rotation == 360)
            {
                rotation = 0;
            }
            while (transform.rotation.eulerAngles.y < (rotation - 1) || transform.rotation.eulerAngles.y > (rotation + 1))
            {
                //Vector3(0,0,0)
                float auxRotation = transform.rotation.eulerAngles.y;
                auxRotation += 2;
                transform.transform.eulerAngles = new Vector3(0, auxRotation, 0);
                yield return null;
            }
            transform.transform.eulerAngles = new Vector3(0, rotation, 0);
            antPosition = transform.position;
            walk = true;
        }
        //if 2 rest 90 degrees
        else
        {
            antRotation = false;
            rotation = transform.rotation.eulerAngles.y;
            rotation -= 90;
            if(rotation == -90)
            {
                rotation = 270;
            }
            while (transform.rotation.eulerAngles.y < (rotation - 1) || transform.rotation.eulerAngles.y > (rotation + 1))
            {
                //Vector3(0,0,0)
                float auxRotation = transform.rotation.eulerAngles.y;
                auxRotation -= 2;
                transform.transform.eulerAngles = new Vector3(0, auxRotation, 0);
                yield return null;
            }
            transform.transform.eulerAngles = new Vector3(0, rotation, 0);
            antPosition = transform.position;
            walk = true;
        }
    }

}
