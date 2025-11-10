using UnityEngine;

public class CorkDropper : MonoBehaviour
{
    public GameObject cork; 
    public float launchForce = 0.2f;

    private bool dropped = false;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == this.gameObject && !dropped)
                {
                    DropCork();
                    dropped = true;
                }
            }
        }
    }

    void DropCork()
    {
        if (cork == null) return;

        Rigidbody rb = cork.GetComponent<Rigidbody>();
        Collider col = cork.GetComponent<Collider>();

     
        if (col != null)
            col.enabled = true;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;


            rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);

       
            rb.AddTorque(Random.insideUnitSphere * 0.2f, ForceMode.Impulse);
        }
    }
}