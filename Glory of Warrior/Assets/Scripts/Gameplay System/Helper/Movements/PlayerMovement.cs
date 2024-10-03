using UnityEngine;
using Zenject;

namespace Gameplay_System.Helper
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
            _characterController.Move(_moveDirection);
        }
        

        private void ApplySpeed()
        {
            _moveDirection = _inputData.MoveDirection;
            _moveDirection *= (Time.deltaTime * _moveSpeed);
            _moveDirection *= (_moveSpeed * Time.deltaTime);
        }
        
        private void RotateForward()
        {
            if (_moveDirection != Vector3.zero)
            {
                _playerTransform.forward = _moveDirection;
            }
        }
    }
}
