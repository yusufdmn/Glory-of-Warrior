using UnityEngine;
using UnityEngine.AI;

namespace Gameplay_System.Helper.Movements
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement: MonoBehaviour, IMovement
    {
        private Vector3 _moveDirection;
        private NavMeshAgent _agent;
        private Transform _target;
        private Vector3 _patrolPoint;

        private readonly float patrolRadius = 10f;
        
        private void Awake()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            SetSpeed(2);
        }

        public void Move()
        { 
            _agent.SetDestination(_target.position);
        }

        public void Patrol()
        {
            if(_agent.remainingDistance < _agent.stoppingDistance + 0.05f)
            {
                _patrolPoint = SetPatrolPoint();
            }
            _agent.SetDestination(_patrolPoint);
        }
        
        public void SetSpeed(int speed)
        {
            _agent.speed = speed;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
        public bool HasTarget()
        {
            return _target;
        }
        
        public Vector3 SetPatrolPoint()
        {
            Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
            randomDirection += transform.position; 

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return Vector3.zero; // If no valid position is found
        }
        
        public void ResetPatrolPoint()
        {
            _patrolPoint = Vector3.zero; 
            StopMovement();
        }
        
        public void StartMovement()
        {
            _agent.isStopped = false;
        }
        
        public void StopMovement()
        {
            _agent.isStopped = true;
        }
        
        public void RotateTowardsTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

    }
}