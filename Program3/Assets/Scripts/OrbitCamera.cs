using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float rotationSpeed = 5f; // Speed of rotation
    public float zoomSpeed = 2f; // Speed of zoom
    public float minZoom = 5f; // Minimum zoom distance
    public float maxZoom = 20f; // Maximum zoom distance

    private float currentZoom = 1f; // Current zoom level
    private Vector3 currentRotation;
    private Vector3 smoothVelocity;
    private Vector3 defaultPosition;
void Start ()
{
    defaultPosition = transform.position;
}

void Update()
{
    //Reset camera view
    if (Input.GetKeyDown(KeyCode.R))
    {
        transform.position = defaultPosition;
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