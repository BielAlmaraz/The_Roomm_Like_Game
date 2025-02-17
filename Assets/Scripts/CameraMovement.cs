using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    public float rotationSpeed = 20000f;
    public float smoothSpeed = 10f;
    public float minYAngle = -60f;
    public float maxYAngle = 60f;
    public float distance = 4f;
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 5f;
    public float inertiaDamping = 15f;

    private Vector3 previousPosition;

    private float currentXRotation = 0f;
    private float currentYRotation = 0f;
    private float inertiaX = 0f;
    private float inertiaY = 0f;

    void Start()
    {
        currentXRotation = cam.transform.eulerAngles.x;
        currentYRotation = cam.transform.eulerAngles.y;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - scroll * zoomSpeed, minZoom, maxZoom);

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            inertiaX = 0f;
            inertiaY = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            float rotationX = direction.y * rotationSpeed;
            float rotationY = -direction.x * rotationSpeed;

            inertiaX = rotationX;
            inertiaY = rotationY;

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else
        {
            inertiaX = Mathf.Lerp(inertiaX, 0, Time.deltaTime * inertiaDamping);
            inertiaY = Mathf.Lerp(inertiaY, 0, Time.deltaTime * inertiaDamping);
        }

        currentXRotation = Mathf.Clamp(currentXRotation + inertiaX * Time.deltaTime, minYAngle, maxYAngle);
        currentYRotation += inertiaY * Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);

            cam.transform.position = target.position;
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
        cam.transform.Translate(new Vector3(0, 0, -distance));
    }
}
