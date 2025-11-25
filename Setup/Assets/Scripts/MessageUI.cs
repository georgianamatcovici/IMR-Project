using System;
using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public TextMeshProUGUI message;
    void Awake()
    {
        if (message != null)
            message.gameObject.SetActive(false);
    }
    public void Show(string text)
    {
        if (message == null) return;
        message.text = text;
        message.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (message == null) return;
        message.gameObject.SetActive(false);
    }
}
