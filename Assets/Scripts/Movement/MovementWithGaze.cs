using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CinemachineCameraTarget;

public class MovementWithGaze : MonoBehaviour
{
    public bool move = false;
    
    private GameObject pointer;

    [SerializeField] public GameObject camera;
    [SerializeField] private float velocidadMovimiento = 0.004f;

    void Start()
    {
        //get script CameraPointerManager
        CameraPointerManager cameraPointerManager = camera.GetComponent<CameraPointerManager>();
        //get pointer from CameraPointerManager
        pointer = cameraPointerManager.pointer;
    }


    void Update()
    {
        //move object to pointer
        if (move)
        {
            //lerp between object and pointer
            Vector3 lerp = Vector3.Lerp(transform.position, pointer.transform.position, velocidadMovimiento);
            
            //set lerp x and z to object
            transform.position = new Vector3(lerp.x, transform.position.y, lerp.z);
        }
        
    }
}