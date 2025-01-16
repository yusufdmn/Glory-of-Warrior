using Gameplay_System.Helper.Weapons;
using Gameplay_System.Model;
using UnityEngine;
using Zenject;

public class OnAttackEnded : StateMachineBehaviour
{
    private PlayerModel _playerModel;
    private Weapon _weapon;
    
    public void Construct(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerModel.StopAttack();
    }

}
