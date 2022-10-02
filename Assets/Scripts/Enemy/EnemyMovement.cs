using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private const string RunAnimation = "IsRun";
        
        private float _cooldownTime;
        private PlayerHealth _target;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _stopDistance = 3f;

        public bool CanMove => _cooldownTime < Time.time;

        private bool InTargetPoint => _target != null &&
            Vector3.Distance(transform.position, 
                _target.transform.position) <= _stopDistance;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth))
            {
                _target = playerHealth;
            }
        }

        private void Update()
        {
            if (_target != null && CanMove && InTargetPoint == false)
            {
                _agent.SetDestination(_target.transform.position);
                //_animator?.SetBool(RunAnimation, true);
            }
            
            _agent.isStopped = CanMove == false || InTargetPoint;
            
            if (_agent.isStopped)
            {
                //_animator?.SetBool(RunAnimation, false);
            }
        }

        private void Stop()
        {
            _agent.SetDestination(transform.position);
        }
    }
}
