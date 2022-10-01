using System;
using UnityEngine;

namespace Upgrade
{
    public class HealthUpgrader : Upgrader
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnValidate()
        {
            if (_playerHealth == null)
                Debug.LogWarning("PlayerHealth was not found!", this);
        }

        protected override void UpgradeHandler()
        {
            _playerHealth.SetStrength(CalculateValue());
        }
    }
}
