using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
   [SerializeField] private List<IItem> _items = new List<IItem>();

    public void AddItem(IItem item)
    {
        _items.Add(item);
    }
}
