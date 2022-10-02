using Experience;
using UnityEngine;
using UnityEngine.Events;

namespace Upgrade.Experience
{
    public class UpgradeStore : MonoBehaviour
    {
        [SerializeField] private ExperienceLevel _experienceLevel;
        [SerializeField] private Upgrader _upgrader;

        public event UnityAction OnBuy;
        
        private void OnValidate()
        {
            if (_experienceLevel == null)
                Debug.LogWarning("ExperienceLevel was not found!", this);
            if (_upgrader == null)
                Debug.LogWarning("Upgrader was not found!", this);
        }

        public void Buy()
        {
            if (_experienceLevel.PointSpend() == false)
                return;
            
            _upgrader.Upgrade();
            OnBuy?.Invoke();
        }
    }
}
