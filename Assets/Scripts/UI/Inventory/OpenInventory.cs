using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;

    public UnityAction InventoryOpened;

    public void OnInventoryButtonClick()
    {
        if(_inventoryPanel.activeSelf == false)
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
        _inventoryPanel.SetActive(false);
    }

    private void OpenPanel()
    {
        _inventoryPanel.SetActive(true);
        InventoryOpened?.Invoke();
    }
}
