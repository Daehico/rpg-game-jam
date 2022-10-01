using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _basicHealth;

    private int _strength;
    private int _maxHealth;
    private int _currenHealth;

    public void SetStrength(int strength)
    {
        _strength = strength;
    }
}
