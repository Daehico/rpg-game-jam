using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _basicHealth;
    [SerializeField] private int _healthForOneStrength;

    private int _strength;
    private int _maxHealth;
    private int _currenHealth;

    public void SetStrength(int strength)
    {
        _strength = strength;
        SetMaxHealth();
    }

    public void ApplyDamage(int damage)
    {
        if(damage < 0)
        {
            throw new ArgumentOutOfRangeException("Damage can not be negative");
        }

        _currenHealth -= damage;
    }

    public void Treatment(int healHealth)
    {
        if(healHealth < 0)
        {
            throw new ArgumentOutOfRangeException("Heal can not be negative");
        }

        _currenHealth += healHealth;

        if(_currenHealth > _maxHealth)
        {
            _currenHealth = _maxHealth;
        }
    }


    private void SetMaxHealth()
    {
        _maxHealth += _strength * _healthForOneStrength;
        _currenHealth = _maxHealth;
    }
}
