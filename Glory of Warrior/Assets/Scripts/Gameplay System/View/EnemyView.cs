using Gameplay_System.Helper;
using UnityEngine;
using Zenject;

namespace Gameplay_System.View
{
    public class EnemyView: MonoBehaviour // It serves more like a detector
    {
        private float _nextUpdateTime;
        private readonly float _chaseRange = 5f;
        private readonly float _attackRange = 1.5f;
        private Transform _chaseTarget;
        private Transform _attackTarget;
        [Inject] private WarriorDetector _chaseDetector;
        [Inject] private WarriorDetector _attackDetector;
        
        public delegate void OnChaseTargetUpdatedDelegate(Transform target);
        public event OnChaseTargetUpdatedDelegate OnChaseTargetUpdated;
        
        public delegate void OnAttackTargetUpdatedDelegate(Transform target);
        public event OnAttackTargetUpdatedDelegate OnAttackTargetUpdated;

        private void Start()
        {
            _chaseDetector.Initialize(transform, _chaseRange);
            _attackDetector.Initialize(transform, _attackRange);
        }
        
        private void Update()
        {
            if (Time.time >= _nextUpdateTime)  // Update targets periodically for a better performance
            {
                _nextUpdateTime = Time.time + 0.5f;
                UpdateTargets();
            }
        }

        private void UpdateTargets() 
        {
            int warriorsInChaseRange = _chaseDetector.SearchInRange();
            int warriorsInAttackRange = _attackDetector.SearchInRange();

            DetectChaseableTarget(warriorsInChaseRange); 

            if (_chaseTarget) // look for attack target if there is a chase target. Otherwise, it won't find any
            {
                DetectAttackableTarget(warriorsInAttackRange);
            }  
        }
        
        private void OnChaseTargetDetected(Transform detectedTarget)
        {
            OnChaseTargetUpdated?.Invoke(detectedTarget);
        }
        
        private void OnAttackTargetDetected(Transform detectedTarget)
        {
            OnAttackTargetUpdated?.Invoke(detectedTarget);
        }
        
        private void DetectChaseableTarget(int warriorsInChaseRange)
        {
            if (warriorsInChaseRange > 0)
            {
                _chaseTarget = _chaseDetector.GetClosestWarriorInRange();
                OnChaseTargetDetected(_chaseTarget);
            }
            else
            {
                _chaseTarget = null;
                OnChaseTargetDetected(null);
            }
        }
        
        private void DetectAttackableTarget(int warriorsInAttackRange)
        {
            if (warriorsInAttackRange > 0)
            {
                _attackTarget = _attackDetector.GetClosestWarriorInRange();
                OnAttackTargetDetected(_attackTarget);
            }
            else
            {
                _attackTarget = null;
                OnAttackTargetDetected(null);
            }
        }
    }
}