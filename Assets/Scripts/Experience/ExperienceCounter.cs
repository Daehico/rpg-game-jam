using DuloGames.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Experience
{
    public class ExperienceCounter : MonoBehaviour
    {
        [SerializeField] private UIProgressBar _progressBar;

        private int _total;

        public event UnityAction OnChange;

        public int Total => _total;
        
        public void AddExperience(int value)
        {
            _total += value;
            Debug.Log("Add " + value + " experience. Total = " + _total);
            _progressBar.fillAmount = _total;
            OnChange?.Invoke();
        }

        public void Reset()
        {
            _total = 0;
            OnChange?.Invoke();
        }
    }
}
