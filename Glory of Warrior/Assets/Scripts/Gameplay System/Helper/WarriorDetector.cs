using UnityEngine;

namespace Gameplay_System.Helper
{
    public class WarriorDetector
    {
        private float _checkInterval = 0.5f; // Check every 0.5 seconds 
        private float _timeSinceLastCheck;
        private float _detectionRange;
        private LayerMask _warriorLayer;
        private Collider[] _warriorsInRange;
        private Transform _ownTransform;
        private Transform _target;
        
        public void Initialize(Transform enemyTransform, float detectionRange)
        {
            _ownTransform = enemyTransform;
            _detectionRange = detectionRange;
            _warriorLayer = LayerMask.GetMask("Warrior");
            _warriorsInRange = new Collider[20]; // 20 is the maximum number of warriors that can be detected
        }
            
        public int SearchInRange()
        {
            int numberOfWarriors = Physics.OverlapSphereNonAlloc(_ownTransform.position, _detectionRange, _warriorsInRange, _warriorLayer);
            if (numberOfWarriors == 0) // If there is only the enemy itself
                _target = null;

            return numberOfWarriors - 1; // extract the enemy itself 
        }

        public Transform GetClosestWarriorInRange() // Get the closest warrior
        {
            ExtractEnemyItself();

            float closestDistance = Mathf.Infinity;
            Collider closestCollider = null;
            foreach (var warriorCollider in _warriorsInRange)
            {
                if(!warriorCollider)
                    continue;
                float distance = Vector3.Distance(_ownTransform.position, warriorCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCollider = warriorCollider;
                }
            }

            _target = closestCollider?.transform;
            return _target;
        }

        
        private void ExtractEnemyItself() // Remove the enemy itself from the detected enemies
        {
            for(int i = 0; i < _warriorsInRange.Length; i++)
            {
                if (_warriorsInRange[i]?.transform == _ownTransform)
                {
                    _warriorsInRange[i] = null;
                    break;
                }
            }
        }

    }
}