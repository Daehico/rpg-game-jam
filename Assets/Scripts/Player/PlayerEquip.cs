using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEquip : MonoBehaviour
{
    private Item _weapon;
    private Item _armor;

    public Item Weapon => _weapon;
    public Item Armor => _armor;

    public UnityAction WeponSet;
    public UnityAction ArmorSet;

    public void SetWeapon(Item item)
    {
        _weapon = item;
        WeponSet?.Invoke();
    }

    public void SetArmor(Item item)
    {
        _armor = item;
        ArmorSet?.Invoke();
    }
}
