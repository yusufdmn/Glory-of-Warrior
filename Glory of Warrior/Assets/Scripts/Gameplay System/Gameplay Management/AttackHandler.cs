using System.Collections.Generic;
using Gameplay_System.Controller;
using Gameplay_System.Model;
using UnityEngine;

namespace Gameplay_System.Gameplay_Management
{
    public class AttackHandler
    {
        private readonly int minDamage = 20;
        private readonly Dictionary<GameObject, WarriorModel> warriors = new ();
        private readonly List<IWarriorController> _warriorControllers = new ();
        
        public void AddWarrior(GameObject warriorObject, WarriorModel warriorModel, IWarriorController warriorController)
        {
            _warriorControllers.Add(warriorController);
            warriors.Add(warriorObject, warriorModel);

            warriorController.OnSuccessfulAttack += DeliverAttackToTarget;
        }

        private void DeliverAttackToTarget(GameObject target, int attackPower)
        {
            int damage = CalculateDamage(attackPower, warriors[target].DefensePower);
            warriors[target].TakeDamage(damage);
        }
        
        private int CalculateDamage(int attackPower, int defensePower)
        {
            return Mathf.Max(attackPower - defensePower, minDamage);
        }

        ~AttackHandler()
        {
            foreach (var controller in _warriorControllers)
            {
                controller.OnSuccessfulAttack -= DeliverAttackToTarget;
            }
        }

    }
}
