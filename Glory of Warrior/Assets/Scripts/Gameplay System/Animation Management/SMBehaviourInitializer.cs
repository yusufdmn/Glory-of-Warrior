using Gameplay_System.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Animation_Management
{
    public class SMBehaviourInitializer: MonoBehaviour // State Machine Behaviour Initializer
    {
        private PlayerModel _playerModel;

        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }
              
        void Start()
        {
            Animator animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
            var stateBehaviours = animator.GetBehaviours<OnAttackEnded>();
            foreach (var behaviour in stateBehaviours)
            {
                behaviour.Construct(_playerModel);
            }
        }
    }
}