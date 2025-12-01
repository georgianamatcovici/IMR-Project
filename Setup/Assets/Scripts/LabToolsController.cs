using UnityEngine;

public class LabToolsController : MonoBehaviour
{
    void Awake()
    {   Debug.Log("LabToolsController Awake!");
        var glass = transform.Find("Table/glass").gameObject;
        var bottle = transform.Find("Table/bottle").gameObject;
        var spatula2 = transform.Find("Table/spatula2").gameObject;
        var pipette = transform.Find("Table/pipette").gameObject;
        var tubes = transform.Find("Table/tubes").gameObject;
        spatula2.SetActive(true);
        glass.SetActive(true);
        bottle.SetActive(true);
        pipette.SetActive(false);
        tubes.SetActive(false);
        int option = PlayerPrefs.GetInt("ChosenOption", 0);
        Debug.Log("Option"+option);
        if (option == 1)
        {
            spatula2.SetActive(false);
            glass.SetActive(false);
            pipette.SetActive(true);
            tubes.SetActive(true);
        }
        
    }
}
