using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlace : MonoBehaviour
{
    public GameObject labToolsPrefab;     
    public float minTableHeight = 0.4f;  
    public float maxTableHeight = 1.2f;   

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool placed = false;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if (placed == true)
            return;

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            if (!placed)
            {
                Instantiate(labToolsPrefab, pose.position, pose.rotation);
                placed = true;

                planeManager.enabled = false;
                foreach (var plane in planeManager.trackables)
                    plane.gameObject.SetActive(false);
            }
        }
    }
}