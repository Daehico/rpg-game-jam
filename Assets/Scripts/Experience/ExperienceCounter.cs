using UnityEngine;
using UnityEngine.Events;

namespace Experience
{
    public class ExperienceCounter : MonoBehaviour
    {
        private int _total;

        public event UnityAction<int> OnAdd;

        public int Total => _total;
        
        public void AddExperience(int value)
        {
            _total += value;
            Debug.Log("Add " + value + " experience. Total = " + _total);
            OnAdd?.Invoke(value);
        }
    }
}
