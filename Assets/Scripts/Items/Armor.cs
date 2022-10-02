using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    [SerializeField] private int _armor;

    public int ArmorNumber => _armor;
}
