using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void OnOpenMenuButtonClick()
    {
        if(_menu.activeInHierarchy == false)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }

    public void CloseMenu()
    {
        _menu.SetActive(false);
    }

    private void OpenMenu()
    {
        _menu.SetActive(true);
    }
}
