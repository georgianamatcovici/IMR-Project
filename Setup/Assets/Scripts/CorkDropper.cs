using UnityEngine;

public class CorkDropper : MonoBehaviour
{
    public GameObject cork; 
    public float launchForce = 0.2f;
    public MessageUI messageUI;  

    private bool dropped = false;

    void Start()
    { 
        messageUI.Show("Tap the cork to remove it from the bottle containing sodium (Na). Sodium is stored under oil for safety.");
    }
    void OnMouseDown()
    {
        if (dropped) return;

        DropCork();
        messageUI.Show("Use the spatula: tap and drag it to take a piece of Na from the bottle.");
        dropped = true;
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