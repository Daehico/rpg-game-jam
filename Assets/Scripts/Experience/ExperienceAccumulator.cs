using UnityEngine;

namespace Experience
{
    public abstract class ExperienceAccumulator : MonoBehaviour
    {
        private ExperienceCounter _counter;

        [SerializeField] private int _experience;
        
        private void Awake()
        {
            _counter = FindObjectOfType<ExperienceCounter>();
        }

        protected void Add()
        {
            _counter.AddExperience(_experience);
        }
    }
}
