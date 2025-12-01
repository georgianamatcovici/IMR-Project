using TMPro;
using UnityEngine;
public class SelectReactionDropDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void OnDropdownChanged(int index)
    {
        string selected = dropdown.options[index].text;
        Debug.Log(selected);
        Debug.Log(index);
        PlayerPrefs.SetInt("ChosenOption", index); 
        PlayerPrefs.Save();
    }
}

