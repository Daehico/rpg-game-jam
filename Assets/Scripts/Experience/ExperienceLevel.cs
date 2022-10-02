using System;
using UnityEngine;
using UnityEngine.Events;

namespace Experience
{
    [RequireComponent(typeof(ExperienceCounter))]
    public class ExperienceLevel : MonoBehaviour
    {
        private ExperienceCounter _counter;
        private int _points, _level;
            
        [SerializeField] private int _maxExperience;

        public event UnityAction OnLevelUp;
        
        public int Points => _points;
        public int Level => _level;
        
        private void Awake()
        {
            _counter = GetComponent<ExperienceCounter>();
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
            }
        }

        public bool PointSpend()
        {
            if (Points == 0)
                return false;

            _points--;
            return true;
        }
    }
}
