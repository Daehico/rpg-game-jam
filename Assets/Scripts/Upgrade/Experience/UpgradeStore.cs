using Experience;
using UnityEngine;
using UnityEngine.Events;

namespace Upgrade.Experience
{
    public class UpgradeStore : MonoBehaviour
    {
        [SerializeField] private ExperienceLevel _experienceLevel;

        public event UnityAction OnBuyHealth, OnBuySpeed;
        
        private void OnValidate()
        {
            if (_experienceLevel == null)
                Debug.LogWarning("ExperienceLevel was not found!", this);
        }

        public void BuyHealth()
        {
            if (_experienceLevel.PointSpend() == false)
                return;
            
            OnBuyHealth?.Invoke();
        }

        public void BuySpeed()
        {
            if (_experienceLevel.PointSpend() == false)
                return;
            
            OnBuySpeed?.Invoke();
        }
    }
}
