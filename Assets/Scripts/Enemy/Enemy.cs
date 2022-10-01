using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException("Damage can not be negative");
        }

        _currentHealth -= damage;
    }

    public void Treatment(int healHealth)
    {
        if (healHealth < 0)
        {
            throw new ArgumentOutOfRangeException("Heal can not be negative");
        }

        _currentHealth += healHealth;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    private void MakeDamage()
    {

    }
}
