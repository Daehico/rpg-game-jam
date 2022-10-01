using UnityEngine;
using UnityEngine.Events;

namespace Upgrade
{
    public abstract class Upgrader : MonoBehaviour
    {
        private int _level;

        [Min(0f), SerializeField] private int _startValue, _increaseFactor;

        public event UnityAction OnUpgrade;

        protected abstract void UpgradeHandler();

        protected int CalculateValue()
        {
            return _startValue + _startValue * _level * _increaseFactor;
        }
        
        public void Upgrade()
        {
            _level++;
            UpgradeHandler();
            OnUpgrade?.Invoke();
        }
    }
}
