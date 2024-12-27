using System;
using UnityEngine;

namespace Gameplay_System.Helper.Weapons
{
    public abstract class Weapon: MonoBehaviour  // There can be new weapon types (ranged weapons) added in the future.
    {
        [SerializeField] private AudioSource _weaponSound; // to play sound when the weapon hits a warrior
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
        
        protected void OnTriggerEnter(Collider other)
        {
            if(other.transform == _ownerOfWeapon) // Ignore collision with the owner of the weapon
                return;
            if (other.gameObject.layer != 6) // Layer 6: Warrior
                return;
            if(!_attacking)
                return;
            AudioPlayer.Instance.playSound(_weaponSound);
            OnSuccessfulAttack?.Invoke(other.gameObject);
            StopAttack();
        }
    }
}