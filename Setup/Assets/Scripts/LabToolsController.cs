using UnityEngine;

public class LabToolsController : MonoBehaviour
{
    void Awake()
    {   Debug.Log("LabToolsController Awake!");
        var glass = transform.Find("Table/glass").gameObject;
        var bottle = transform.Find("Table/bottle").gameObject;
        var spatula2 = transform.Find("Table/spatula2").gameObject;
        var pipette = transform.Find("Table/pipette/pipette").gameObject;
        var tube = transform.Find("Table/mytube/tube").gameObject;
        var fire = transform.Find("Table/fire").gameObject;
        var alcoholBottle = transform.Find("Table/alcohol_bottle").gameObject;
        spatula2.SetActive(true);
        glass.SetActive(true);
        bottle.SetActive(true);
        pipette.SetActive(false);
        tube.SetActive(false);
        fire.SetActive(false);
        alcoholBottle.SetActive(false);
        int option = PlayerPrefs.GetInt("ChosenOption", 0);
        Debug.Log("Option"+option);
        if (option == 2 || option==4 || option==6)
        {
            spatula2.SetActive(false);
            glass.SetActive(false);
            fire.SetActive(false);
            alcoholBottle.SetActive(false);
            pipette.SetActive(true);
            tube.SetActive(true);
        }
        else
        {
             if (option==3||option==7)
            {
                spatula2.SetActive(false);
                glass.SetActive(false);
                bottle.SetActive (false);
                fire.SetActive(true);
                alcoholBottle.SetActive(true);
                pipette.SetActive(false);
                tube.SetActive(true);
            }
        }
        Debug.Log("OK");
        
    }
}
