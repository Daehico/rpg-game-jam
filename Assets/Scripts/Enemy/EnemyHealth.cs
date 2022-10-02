using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        private int _currentHealth;

        public event UnityAction OnDie;

        public int CurrentHealth => _currentHealth;
        
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

        private void Die()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
