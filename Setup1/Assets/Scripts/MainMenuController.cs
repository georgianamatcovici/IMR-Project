using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
 
    public string arSceneName = "SampleScene";

 
    public void OnPlayPressed()
    {
        // PlayerPrefs.SetInt("ChosenOption", 2); 
        // PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
}
