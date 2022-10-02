using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Upgrade.Experience
{
    public class SpeedUpgrader : Upgrader
    {
        private UpgradeStore _upgradeStore;

        protected override void Awake()
        {
            base.Awake();
            _upgradeStore = FindObjectOfType<UpgradeStore>();
        }

        private void OnEnable()
        {
            _upgradeStore.OnBuySpeed += Upgrade;
        }

        private void OnDisable()
        {
            _upgradeStore.OnBuySpeed -= Upgrade;
        }
    }
}
