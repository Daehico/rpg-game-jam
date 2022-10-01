using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private List<IItem> _items = new List<IItem>();

    private InventoryViev _inentoryViev;

    private void Awake()
    {
        _inentoryViev = FindObjectOfType<InventoryViev>();
    }

    public void AddItem(IItem item)
    {
        _items.Add(item);
        _inentoryViev.SetItems(_items);
    }
}
