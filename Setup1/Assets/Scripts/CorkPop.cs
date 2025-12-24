using UnityEngine;

public class CorkPop : MonoBehaviour
{
    private Rigidbody rb;
    private bool popped = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;     
        rb.isKinematic = true;      
    }

    public void Pop()
    {
        if (popped) return;
        popped = true;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * 2.2f, ForceMode.Impulse);
    }
}