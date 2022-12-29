using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject pointer;
    [SerializeField] private float maxDistancePointer;
    [SerializeField] private GameObject bombButton;
    [SerializeField] public bool move;
    [Range(0, 1)]
    [SerializeField] private float disPointerObject = 0.95f;




    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    private float timeWait = 0.1f;

    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;


    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
        //find by tag
   
    }

    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>


    public void Update()
    {

        try
        {
            //roto el player, se tiene en cuenta que también se rota la camara, para eso el auxRotation
            bombButton.transform.eulerAngles =new Vector3(0, transform.rotation.eulerAngles.y, bombButton.transform.rotation.z);
            
        


                
            // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
            // at.
            RaycastHit hit;
            //draw ray
            Debug.DrawRay(transform.position, transform.forward * maxDistancePointer, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistancePointer))
            {
                // GameObject detected in front of the camera.
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    // New GameObject.
                try{
                    _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                    _gazedAtObject = hit.transform.gameObject;
                    // try{
                    //     //get sound from object
                    //     AudioSource audio = _gazedAtObject.GetComponent<AudioSource>();
                    //     //play sound
                    //     audio.Play();
                        

                    // }catch{
                    //     Debug.Log("No sound");
                    // }
                    
                    _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                    GazeManager.Instance.StartGazeSelection();
                }
                    catch
                    {
                    }
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
                // No GameObject detected in front of the camera.
                
                try{
                    _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                    _gazedAtObject = null;
                }
                catch
                {

                }
            }

            // Checks for screen touches.
            if (Google.XR.Cardboard.Api.IsTriggerPressed)
            {
                try{
                    _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
                }
                catch
                {
                    
                }
            }
        }
        catch
        {
            
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


