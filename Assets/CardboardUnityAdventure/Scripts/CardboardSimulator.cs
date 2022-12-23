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

#if UNITY_ANDROID
        if (!UseCardboardSimulator)
            return;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float mouseX = touch.deltaPosition.x * horizontalSpeed;
                float mouseY = touch.deltaPosition.y * verticalSpeed;
                rotationY += mouseX/3;
                rotationX -= mouseY/3;
                rotationX = Mathf.Clamp(rotationX, -45, 45);
                cam.transform.eulerAngles = new Vector3(rotationX, rotationY, 0.0f);
            }
        }
#endif
    }

}
