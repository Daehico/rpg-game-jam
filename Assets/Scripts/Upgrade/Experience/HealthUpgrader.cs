using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Upgrade.Experience
{
    public class HealthUpgrader : Upgrader
    {
        private UpgradeStore _upgradeStore;

        protected override void Awake()
        {
            base.Awake();
            _upgradeStore = FindObjectOfType<UpgradeStore>();
        }

        private void OnEnable()
        {
            _upgradeStore.OnBuyHealth += Upgrade;
        }

        private void OnDisable()
        {
            _upgradeStore.OnBuyHealth -= Upgrade;
        }
    }
}
