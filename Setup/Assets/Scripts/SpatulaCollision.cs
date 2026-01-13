using UnityEngine;

public class SpatulaCollision : MonoBehaviour
{
    public GameObject indicator;
    public string bottleTag = "Bottle";
    public string waterTag = "water";
    public MessageUI messageUI;
    private int option;
    [SerializeField] private GameObject bubles;

    void Start()
    {
        indicator.SetActive(false);
        option = PlayerPrefs.GetInt("ChosenOption", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(bottleTag) || string.IsNullOrEmpty(waterTag))
            return;

        if (!string.IsNullOrEmpty(other.tag) && other.CompareTag(bottleTag))
        {
            indicator.SetActive(true);
            messageUI.Show("Drag the piece of Na into the water with phenolphthalein");
        }
        
        else if (!string.IsNullOrEmpty(other.tag) && other.CompareTag("water"))
        {
            indicator.SetActive(false);
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                if (option == 1)
                {
                    rend.material.color = new Color(1f, 0.4f, 0.7f, 0.5f);
                    messageUI.Show("Look! The water is now pink, indicating the Na reacted with water.\nPress the 'Animation' button to observe the molecular transformations occurring during the reaction.");
                }
                else if(option==5)
                {
                    bubles.SetActive(true);
                }
                }
        }
    }
}