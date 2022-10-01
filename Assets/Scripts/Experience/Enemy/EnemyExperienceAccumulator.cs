using System;
using Enemy;
using UnityEngine;

namespace Experience.Enemy
{
    public class EnemyExperienceAccumulator : ExperienceAccumulator
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnValidate()
        {
            if (_enemyHealth == null)
                Debug.LogWarning("EnemyHealth was not found!", this);
        }
            
        private void OnEnable()
        {
            _enemyHealth.OnDie += Add;
        }

        private void OnDisable()
        {
            _enemyHealth.OnDie -= Add;
        }
    }
}
