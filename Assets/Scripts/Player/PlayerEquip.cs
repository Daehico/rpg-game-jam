using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Item _weapon;
    private Item _armor;

    public Item Weapon => _weapon;
    public Item Armor => _armor;

    public void SetWeapon(Item item)
    {
        _weapon = item;
    }

    public void SetArmor(Item item)
    {
        _armor = item;
    }
}
