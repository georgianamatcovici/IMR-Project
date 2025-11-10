using UnityEngine;

public class SpatulaCollision : MonoBehaviour
{
    public GameObject indicator;
    public string bottleTag = "Bottle";
    public string waterTag = "water";

    void Start()
    {
        indicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(bottleTag) || string.IsNullOrEmpty(waterTag))
            return;

        if (!string.IsNullOrEmpty(other.tag) && other.CompareTag(bottleTag))
        {
            indicator.SetActive(true);
        }
        
        else if (!string.IsNullOrEmpty(other.tag))
        {
            indicator.SetActive(false);
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = new Color(1f, 0.4f, 0.7f, 0.5f);
            }
        }
    }
}