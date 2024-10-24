using UnityEngine;

namespace Gameplay_System.Animation_Management
{ 
    public class PlayerAnimationManager: MonoBehaviour, IAnimationManager
    {
        private readonly int _runParameter = Animator.StringToHash("run");
        private readonly int _dieParameter = Animator.StringToHash("die");
        private Animator _animator;
        [SerializeField] private RuntimeAnimatorController _animatorController;
        
        private void Awake()
        {
            _animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
            _animator.runtimeAnimatorController = _animatorController;
        }

        public void Attack(int attackParameter)
        {
            _animator.SetTrigger(attackParameter);
        }
        public void StartRun()
        {
            _animator.SetBool(_runParameter, true);
        }
        public void StopRun()
        {
            _animator.SetBool(_runParameter, false);
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