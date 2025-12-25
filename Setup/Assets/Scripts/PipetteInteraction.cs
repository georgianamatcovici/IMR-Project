using UnityEngine;

public class PipetteInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject indicator;
    public string bottleTag = "Bottle";
    public string tubeTag = "Tube";
    [SerializeField] private Renderer tubeRenderer;
    [SerializeField] private GameObject bubles;
    private int option;
    void Start()
    {
        indicator.SetActive(false);
        Debug.Log("OK1");
        option = PlayerPrefs.GetInt("ChosenOption", 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Other!");
        if (string.IsNullOrEmpty(bottleTag) || string.IsNullOrEmpty(tubeTag))
            return;

        if (!string.IsNullOrEmpty(other.tag) && other.CompareTag(bottleTag))
        {
            indicator.SetActive(true);
            Debug.Log("OK2");
            // messageUI.Show("Drag the piece of Na into the water with phenolphthalein");
        }

        else if (!string.IsNullOrEmpty(other.tag) && other.CompareTag("Tube"))
        {
            indicator.SetActive(false);
            Debug.Log("OK3");
            Debug.Log(option);
            if (tubeRenderer!= null)
            { if (option == 2)
                {
                    tubeRenderer.material.color = new Color(0.0f, 0.4f, 0.0f, 1f);
                    Debug.Log("2");
                }
                else if (option == 4)
                {
                    tubeRenderer.material.color = new Color(0.118f, 0.569f, 0.584f, 0.5f);
                    bubles.SetActive(true);
                    Debug.Log("4");
                }
                // messageUI.Show("Look! The water is now pink, indicating the Na reacted with water.\nPress the 'Animation' button to observe the molecular transformations occurring during the reaction.");
            }
            //Renderer rend = other.GetComponent<Renderer>();
            //if (rend != null)
            //{
            //    rend.material.color = new Color(1f, 0.4f, 0.7f, 0.5f);
            // //   messageUI.Show("Look! The water is now pink, indicating the Na reacted with water.\nPress the 'Animation' button to observe the molecular transformations occurring during the reaction.");
            //}
        }
    }
}
