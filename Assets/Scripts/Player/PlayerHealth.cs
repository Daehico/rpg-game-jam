using DuloGames.UI;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using Upgrade;

public class PlayerHealth : MonoBehaviour, IUpgradable
{
    [SerializeField] private int _basicHealth;
    [SerializeField] private int _healthForOneStrength;
    [SerializeField] private UIProgressBar _progressBar;

    private int _strength;
    private int _maxHealth;
    private int _currenHealth;

    private void Awake()
    {
        if(_strength <= 0)
        {
            _strength = 1;
        }
        _maxHealth += _basicHealth + (_healthForOneStrength * _strength);
        _currenHealth = _maxHealth;

        _progressBar.fillAmount = _currenHealth;
    }

    public void Upgrade(int strength)
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

        if(_currenHealth <= 0)
        {
            Die();
        }

        _progressBar.fillAmount = _currenHealth;
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

    private void Die()
    {
        Debug.Log("ГГ вы проебали");
    }
}
