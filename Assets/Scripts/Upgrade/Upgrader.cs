using UnityEngine;
using UnityEngine.Events;

namespace Upgrade
{
    public class Upgrader : MonoBehaviour
    {
        private int _level;

        [Min(0), SerializeField] private int _startValue;
        [Min(0), SerializeField] private float _increaseFactor;

        [SerializeField] private MonoBehaviour _upgradableBehaviour;
        private IUpgradable UpgradableInterface => 
            (IUpgradable)_upgradableBehaviour;

        public event UnityAction OnUpgrade;
        
        private void OnValidate()
        {
            if (_upgradableBehaviour is IUpgradable == false)
            {
                Debug.LogError(_upgradableBehaviour.name + " needs to implement " + nameof(IUpgradable), this);
                _upgradableBehaviour = null;
            }
        }

        private void Awake()
        {
            UpgradeHandler();
        }

        private void UpgradeHandler()
        {
            UpgradableInterface.Upgrade(CalculateValue()); 
        }

        private int CalculateValue()
        {
            var increase = (int)(_startValue * _level * _increaseFactor);
            return _startValue + increase;
        }
        
        public void Upgrade()
        {
            _level++;
            UpgradeHandler();
            Debug.Log("Level = " + _level + " new value = " + CalculateValue());
            OnUpgrade?.Invoke();
        }
    }
}
