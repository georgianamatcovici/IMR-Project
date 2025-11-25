using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlace : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject labToolsPrefab;     
    public GameObject molecularAnimationPrefab;

    [Header("AR Settings")]
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
        if (placed)
            return;

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            // Instanțiere doar o dată
            var labTools = Instantiate(labToolsPrefab, pose.position, pose.rotation);
            var reaction = Instantiate(molecularAnimationPrefab, labTools.transform);
            reaction.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);   // mai mic
            reaction.transform.localPosition = new Vector3(-0.1f, 0.4f, 0f);

            var buttonScript = labTools.GetComponentInChildren<ButtonScript>();
            
                if (buttonScript != null)
                {
                    buttonScript.animator = reaction.GetComponent<Animator>();
                }
            

            placed = true; // blocăm instanțierea ulterioară

            // Dezactivăm plane manager și planele
            planeManager.enabled = false;
            foreach (var plane in planeManager.trackables)
                plane.gameObject.SetActive(false);
        }
    }
}
