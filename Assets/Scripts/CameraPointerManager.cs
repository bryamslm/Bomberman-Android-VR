using System.Collections;
using System.Collections.Generic;
//using System.Drawing.Text;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject pointer;
    [SerializeField] private float maxDistancePointer;
    [SerializeField] private GameObject bombButton;
    [Range(0, 1)]
    [SerializeField] private float disPointerObject = 0.95f;
    [SerializeField] private BombButton bombButtonScript;



    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    private float timeWait = 0.1f;

    private readonly string interactableTag = "Interactable";
    private readonly string paredTag = "pared";
    private readonly string enemieTag = "Enemie";
    private float scaleSize = 0.025f;


    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
        //find by tag
   
    }

    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);

        if(_gazedAtObject.transform.CompareTag(paredTag) || _gazedAtObject.transform.CompareTag(enemieTag))
        {
            
            bombButtonScript.PutBomb();
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>


    public void Update()
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
                    
                    if (_gazedAtObject != hit.transform.gameObject)
                    {
                        
                        
                        // New GameObject.
                                        
                               if(_gazedAtObject != null)
                                {
                                     _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                                }
                                //_gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                                _gazedAtObject = hit.transform.gameObject;
                                
                                _gazedAtObject?.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                                GazeManager.Instance.StartGazeSelection();
                                Debug.Log("On Gaze Enter");
                            
                            
                        
                    }
                    if (hit.transform.CompareTag(interactableTag) || hit.transform.CompareTag(paredTag) || hit.transform.CompareTag(enemieTag))
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
                
             
                    _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                    _gazedAtObject = null;
               
            }

            // Checks for screen touches.
            if (Google.XR.Cardboard.Api.IsTriggerPressed)
            {
                
                    _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
                
            }
       
    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scalefactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scalefactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint,disPointerObject);
    }

    public void PointerOutGaze()
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