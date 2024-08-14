using System;
using System.Runtime.CompilerServices;
using Gameplay_System.Player.Model;
using UnityEngine;
using Zenject;

namespace Gameplay_System.Player.View
{
    public class PlayerView: MonoBehaviour
    {
        private bool _isMoving;
        private Vector3 _moveDirection;

        // Delegates - Events for player state machine
        public delegate void OnAttackButtonDelegate();
        public event OnAttackButtonDelegate OnAttackButtonClicked;
        public delegate void OnMoveChangedDelegate(bool isMoving);
        public event OnMoveChangedDelegate OnMoveChanged;
       
        
        public void OnAttackButton() // for attack button 
        {
            OnAttackButtonClicked?.Invoke();
        }
        
        private void Update()
        {
            UpdateMovementData();
        }

        private void UpdateMovementData()
        {
            _moveDirection.x = Input.GetAxis("Horizontal");
            _moveDirection.z = Input.GetAxis("Vertical");
            
            if(_isMoving && _moveDirection.magnitude <= 0.1f)
                StopMove();
            else if(!_isMoving && _moveDirection.magnitude >= 0.1f)
                StartMove();
        }

        private void StartMove()
        {
            _isMoving = true;
            OnMoveChanged?.Invoke(_isMoving);
        }

        private void StopMove()
        {
            _isMoving = false;
            OnMoveChanged?.Invoke(_isMoving);
        }
        
    }
}