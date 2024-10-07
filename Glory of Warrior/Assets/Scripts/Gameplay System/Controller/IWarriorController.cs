using UnityEngine;

namespace Gameplay_System.Controller
{
    public interface IWarriorController
    {
        delegate void OnSuccessfulAttackDelegate(GameObject target, int attackPower);
        event OnSuccessfulAttackDelegate OnSuccessfulAttack;
    }
}