using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardSimulator : MonoBehaviour
{
    public bool UseCardboardSimulator = true;

    [SerializeField] private float horizontalSpeed = 0.5f;
    [SerializeField] private float verticalSpeed = 0.5f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private Camera cam;

    void Start() { cam = Camera.main; }
    void Update()
    {
#if UNITY_EDITOR
        if (!UseCardboardSimulator)
            return;
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed; 
            rotationY += mouseX*2.5f;
            rotationX -= mouseY*2.5f;

            rotationX = Mathf.Clamp(rotationX, -45, 45);
            cam.transform.eulerAngles = new Vector3(rotationX, rotationY, 0.0f);
        }
#endif
    }

}
