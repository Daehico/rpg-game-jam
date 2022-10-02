using System;
using DuloGames.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Experience
{
    [RequireComponent(typeof(ExperienceCounter))]
    public class ExperienceLevel : MonoBehaviour
    {
        private ExperienceCounter _counter;
        private int _points, _level;
            
        [SerializeField] private int _maxExperience;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private UIProgressBar _progressBar;
        [SerializeField] private Text _pointsText;

        public event UnityAction OnLevelUp;
        
        public int Points => _points;
        public int Level => _level;
        
        private void Awake()
        {
            _counter = GetComponent<ExperienceCounter>();
            SetLevelText();
        }

        private void OnEnable()
        {
            _counter.OnChange += ChangeExperianceHandler;
        }

        private void OnDisable()
        {
            _counter.OnChange -= ChangeExperianceHandler;
        }

        private void ChangeExperianceHandler()
        {
            if (_maxExperience <= _counter.Total)
            {
                var points = (int)Mathf.Floor(
                    _counter.Total / (float)_maxExperience);
                var remainder = _counter.Total - points * _maxExperience;
                _points += points;
                _level += points;
                _counter.Reset();
                _counter.AddExperience(remainder);
                Debug.Log("LevelUp " + _level + ", points = " + _points);
                SetLevelText();
            }
        }

        public bool PointSpend()
        {
            if (Points == 0)
                return false;

            _points--;
            SetLevelText();
            return true;
        }

        private void SetLevelText()
        {
            _pointsText.text = _points.ToString();
            _progressBar.fillAmount = _counter.Total / (float)_maxExperience;
            _levelText.text = _level.ToString();
        }
    }
}
