using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlayerPanell : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OnPlayerPanelButtonClick()
    {
        if (_panel.activeSelf == false)
        {
            OpenPanel();
        }
        else
        {
            ClosePanel();
        }
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
    }

    private void OpenPanel()
    {
        _panel.SetActive(true);
    }
}
