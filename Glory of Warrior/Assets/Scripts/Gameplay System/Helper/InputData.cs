using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay_System.Helper
{
    public class InputData: MonoBehaviour // Temporary Input System
    {
        private Transform _mainCameraTransform;

        
        public Vector3 MoveDirection { get; private set; } = Vector3.zero;

        private void Start()
        {
            _mainCameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            UpdateMoveDirection();
        }
        
        public bool DetectAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                return true; // Attack!
            return false;
        }
        
        private void UpdateMoveDirection()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 forward = _mainCameraTransform.forward;
            Vector3 right = _mainCameraTransform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();
            MoveDirection = right * x + forward * z;
        }
    }
}