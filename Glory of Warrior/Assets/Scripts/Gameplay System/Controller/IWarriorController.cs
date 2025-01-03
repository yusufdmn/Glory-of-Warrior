using UnityEngine;

namespace Gameplay_System.Controller
{
    public delegate void OnSuccessfulAttackDelegate(GameObject target, int attackPower);

    public interface IWarriorController
    {
        event OnSuccessfulAttackDelegate OnSuccessfulAttack;
    }
}