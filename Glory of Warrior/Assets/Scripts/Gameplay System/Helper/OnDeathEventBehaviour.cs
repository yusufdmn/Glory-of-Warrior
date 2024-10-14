using UnityEngine;

namespace Gameplay_System.Helper
{
    public class OnDeathEventBehaviour : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GameObject character = animator.gameObject;
            character.SetActive(false);
        }
    }
}
