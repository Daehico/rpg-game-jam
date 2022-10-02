using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ussable : Item
{
    [SerializeField] private int _healPoints;

    public int HealPonts => _healPoints;
}
