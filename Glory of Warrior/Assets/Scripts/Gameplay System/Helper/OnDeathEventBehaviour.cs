using UnityEngine;

namespace Gameplay_System.Helper
{
    public class OnDeathEventBehaviour : StateMachineBehaviour
    {
        // public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     GameObject character = animator.gameObject;
        //     character.SetActive(false);
        // }
        
        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // set gameobject of the animator to inactive when the current state came to the end by checking its time.
            if (stateInfo.normalizedTime >= 0.95f)
            { 
                animator.gameObject.SetActive(false);;
            }
        }
    }
}
