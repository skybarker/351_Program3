using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; 
    public float rotationSpeed = 5f; 
    public float zoomSpeed = 2f; 
    public float minZoom = 5f; 
    public float maxZoom = 20f; 

    private float currentZoom = 10f; 
    private Vector3 currentRotation;
    private Vector3 smoothVelocity;
    private Vector3 defaultPosition = new Vector3(-0.5f, 3f, -40f);
    private Vector3 defaultRotation = new Vector3(20,0,0);


    void Start()
    {
            transform.position = defaultPosition;
            currentRotation = defaultRotation;
            transform.LookAt(target);
    }

    void Update()
    {
        //Reset camera view
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = defaultPosition;
            currentRotation = defaultRotation;
            transform.LookAt(target);
        }
        // Rotate camera on mouse drag
        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;
            currentRotation += new Vector3(vertical, horizontal, 0);
        }

        // Zoom in/out with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        // Smoothly rotate and position the camera
        Quaternion rotation = Quaternion.Euler(currentRotation);
        Vector3 position = target.position - (rotation * Vector3.forward * currentZoom);
        transform.position = position;
        transform.LookAt(target);
    }
}