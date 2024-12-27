using UnityEngine;
using Zenject;

namespace Gameplay_System.Helper.Movements
{
    public class PlayerMovement : MonoBehaviour, IMovement // Attached to an empty GameObject
    {
        private Vector3 _moveDirection;
        private Transform _playerTransform;
        private CharacterController _characterController;
        [Inject] private InputData _inputData;
        [SerializeField] private float _moveSpeed;

        private void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            _playerTransform = player.transform;
            _characterController = player.GetComponent<CharacterController>();
        }

        public void Move()
        {
            ApplySpeed();
            RotateForward();
            MoveWithGravity(); // Added function to handle gravity
        }

        private void ApplySpeed()
        {
            _moveDirection = _inputData.MoveDirection;
            _moveDirection.y = 0; // Set vertical movement to 0
            _moveDirection *= _moveSpeed * Time.deltaTime;
        }

        private void RotateForward()
        {
            if (_moveDirection != Vector3.zero)
            {
                _playerTransform.forward = _moveDirection;
            }
        }

        private void MoveWithGravity()
        {
            _moveDirection.y += Physics.gravity.y * Time.deltaTime; // Apply gravity
            _characterController.Move(_moveDirection);
        }
    }
}