using UnityEngine;
using UnityEngine.Events;

namespace Experience
{
    public class ExperienceCounter : MonoBehaviour
    {
        private int _total;

        public event UnityAction<int> OnAdd;
        
        public void AddExperience(int value)
        {
            _total += value;
            Debug.Log("Add " + value + " experiance. Total = " + _total);
            OnAdd?.Invoke(value);
        }
    }
}
