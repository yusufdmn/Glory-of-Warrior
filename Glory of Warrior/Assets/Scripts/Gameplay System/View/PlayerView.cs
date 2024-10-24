using Gameplay_System.Helper;
using Helper;
using UnityEngine;
using Zenject;

namespace Gameplay_System.View
{
    public class PlayerView: MonoBehaviour
    {
        [Inject] private InputData _inputData;
        
        private GameObject _playerObject;
        private bool _isMoving;
        private Vector3 _moveDirection;

        // Delegates - Events for player state machine
        public delegate void OnAttackButtonDelegate();
        public event OnAttackButtonDelegate OnAttackButtonClicked;
        public delegate void OnMoveChangedDelegate(bool isMoving);
        public event OnMoveChangedDelegate OnMoveChanged;
       
        
        private void Start()
        {
            _playerObject = GameObject.FindWithTag("Player");
      //      _playerObject.AddComponent<SkinnedMeshCombiner>();
        }
        
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
            _moveDirection = _inputData.MoveDirection;
            
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