using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerBasicManager : MonoBehaviour
{
       // Start is called before the first frame update
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 4.5f;
    [Range(0, 1)]
    [SerializeField] private float disPointerObject = 0.95f;

    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;


    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        if (_gazedAtObject.name == "StartGame")
        {
            _gazedAtObject?.SendMessage("loadGame", null, SendMessageOptions.DontRequireReceiver);
        }
        if (_gazedAtObject.name == "AboutUs")
        {
            _gazedAtObject?.SendMessage("loadAbout", null, SendMessageOptions.DontRequireReceiver);
        }
        if (_gazedAtObject.name == "Return")
        {
            _gazedAtObject?.SendMessage("loadMenu", null, SendMessageOptions.DontRequireReceiver);
        }
        if(_gazedAtObject.CompareTag(interactableTag))
        {
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
        }
        if (_gazedAtObject.name == "akion")
        {
            _gazedAtObject?.SendMessage("loadAkionAnimation", null, SendMessageOptions.DontRequireReceiver);
        }
        if (_gazedAtObject.name == "bryam")
        {
            _gazedAtObject?.SendMessage("loadBryamAnimation", null, SendMessageOptions.DontRequireReceiver);
        }
        if (_gazedAtObject.name == "reyner")
        {
            _gazedAtObject?.SendMessage("loadReynerAnimation", null, SendMessageOptions.DontRequireReceiver);
        }


            
    }

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
                GazeManager.Instance.StartGazeSelection();
                _gazedAtObject = hit.transform.gameObject;
            }
            if (hit.transform.CompareTag(interactableTag))
            {
                PointerOnGaze(hit.point);
            }
            else
            {
                PointerOutGaze();
            }

        }
        else
        {
            
            _gazedAtObject = null;
        }


    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scalefactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scalefactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint,disPointerObject);
    }

    private void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one*0.1f;
        pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
        pointer.transform.parent.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }

    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
    }
}
