using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryViev : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _template;

    private OpenInventory _openInventory;
    private List<IItem> _items = new List<IItem>();
    private List<IItem> _drawedItems = new List<IItem>();

    private void Awake()
    {
        _openInventory = FindObjectOfType<OpenInventory>();
    }

    private void OnEnable()
    {
        _openInventory.InventoryOpened += DrawInvemtory;
    }

    private void OnDisable()
    {
        _openInventory.InventoryOpened -= DrawInvemtory;
    }

    public void SetItems(List<IItem> items)
    {
        _items = items; 
    }

    private void DrawInvemtory()
    {
        if(_drawedItems.Count != 0)
        {
            foreach (Item drawItem in _drawedItems)
            {
                Destroy(drawItem.gameObject);
            }

            _drawedItems.Clear();
        }          

        foreach(var item in _items)
        {
            _template.GetComponentInChildren<Image>().sprite = item.Icon;
            Instantiate(_template, _panel.transform);
            _drawedItems.Add(item);           
        }
    }
}
