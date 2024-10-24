using UnityEngine;

namespace Gameplay_System.Animation_Management
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimationManager: MonoBehaviour, IAnimationManager
    {
        private readonly int _idleParameter = Animator.StringToHash("Idle");
        private readonly int _dieParameter = Animator.StringToHash("die");
        private Animator _animator;

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
        }
        
        public void Attack(int attackParameter)
        {
            _animator.SetTrigger(attackParameter);
        }
        public void StartRun()
        {
            _animator.SetBool(_idleParameter, false);
        }
        public void StopRun()
        {
            _animator.SetBool(_idleParameter, true);
        }
        public void Die()
        {
            _animator.SetTrigger(_dieParameter);
        }

        public AnimatorStateInfo GetCurrentState()
        {
            return _animator.GetCurrentAnimatorStateInfo(1);
        }
        
    }
}