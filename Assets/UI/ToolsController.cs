using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolsController : MonoBehaviour
{
    public GameObject alert;
    public GameObject loader;

    public TMPro.TextMeshProUGUI message;

    private void CloseAlert()
    {
        alert.SetActive(false);
    }

    private void CloseLoader()
    {
        loader.SetActive(false);
    }

    public void Close()
    {
        CloseAlert();
        CloseLoader();
        gameObject.SetActive(false);
    }

    public void ShowAlert(string text)
    {
        message.text = text;
        CloseLoader();
        alert.SetActive(true);
        gameObject.SetActive(true);
    }

    public void ShowLoader()
    {
        CloseAlert();
        loader.SetActive(true);
        gameObject.SetActive(true);
    }
}
