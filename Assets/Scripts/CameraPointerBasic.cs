using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerBasic : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
      
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {

                _gazedAtObject = hit.transform.gameObject;

            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject = null;
        }


    }
}
