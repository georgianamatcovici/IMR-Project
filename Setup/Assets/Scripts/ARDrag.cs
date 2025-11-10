using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARDragFixedPlane : MonoBehaviour
{
    [Header("AR References")]
    public Camera arCamera;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [Header("Drag Settings")]
    public string draggableTag = "Draggable";
    public float dragHeightOffset = 0.02f;   
    public bool keepZFixed = true;    

    [Header("Movement Limits")]
    public float minX = -10f;  
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 5f;    

    private Transform selectedObject;
    private Vector3 touchOffset;
    private bool isDragging = false;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();

        if (arCamera == null)
            arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 0)
        {
            isDragging = false;
            selectedObject = null;
            return;
        }

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                TrySelectObject(touch.position);
                break;

            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                if (isDragging && selectedObject != null)
                    DragSelectedObject(touch.position);
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                isDragging = false;
                selectedObject = null;
                break;
        }
    }

    void TrySelectObject(Vector2 touchPos)
    {
        Ray ray = arCamera.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(draggableTag))
            {
                selectedObject = hit.transform;
                isDragging = true;

            
                if (raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
                {
                    Vector3 hitPlanePos = hits[0].pose.position;
                    touchOffset = selectedObject.position - hitPlanePos;
                    touchOffset.y += dragHeightOffset;
                }
                else
                {
                    Vector3 worldPos = arCamera.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 0.5f));
                    touchOffset = selectedObject.position - worldPos;
                }
            }
        }
    }

    void DragSelectedObject(Vector2 touchPos)
    {
        if (selectedObject == null) return;

        Vector3 newPosition;

        if (raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            newPosition = pose.position + touchOffset;
        }
        else
        {
            Vector3 screenPos = new Vector3(touchPos.x, touchPos.y, Vector3.Distance(arCamera.transform.position, selectedObject.position));
            Vector3 worldPos = arCamera.ScreenToWorldPoint(screenPos);
            newPosition = worldPos + touchOffset;
        }


        if (keepZFixed)
            newPosition.z = selectedObject.position.z;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        selectedObject.position = newPosition;
    }
}
