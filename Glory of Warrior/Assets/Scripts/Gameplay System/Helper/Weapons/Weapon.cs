using UnityEngine;

namespace Gameplay_System.Helper.Weapons
{
    public abstract class Weapon: MonoBehaviour  // There can be new weapon types (ranged weapons) added in the future.
    {
        private Transform _ownerOfWeapon;
        private bool _attacking;
        
        public delegate void OnSuccessfulAttackDelegate(GameObject target);
        public event OnSuccessfulAttackDelegate OnSuccessfulAttack; // When the weapon hits a warrior

        public string AnimationName { get; protected set; }

        void Start()
        {
            _ownerOfWeapon = transform.root;
        }
        
        public virtual void Attack()
        {
            _attacking = true;
            //play sound and particle effects if exists
        }

        public virtual void StopAttack()
        {
            _attacking = false;
        }
        
        
        protected virtual void OnCollisionEnter(Collision other)
        {
            if(other.transform == _ownerOfWeapon) // Ignore collision with the owner of the weapon
                return;
            if (other.gameObject.layer != 6) // Layer 6: Warrior
                return;
            if(!_attacking)
                return;
            
            OnSuccessfulAttack?.Invoke(other.gameObject);
            StopAttack();
        }
        
    }
}