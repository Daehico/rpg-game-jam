using System;
using System.Collections;
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

        if(_currentHealth <= 0)
        {
            Die();
        }
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

    public void MakeDamage(PlayerHealth playerHealth)
    {
        StartCoroutine(AttackWithDelay(playerHealth));
    }

    private IEnumerator AttackWithDelay(PlayerHealth playerHealth)
    {
        yield return new WaitForSeconds(3f);
        playerHealth.ApplyDamage(_damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
