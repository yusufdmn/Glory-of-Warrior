using System;
using Cinemachine;
using UnityEngine;

namespace Gameplay_System.Helper
{
    public class MouseCameraMovement : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float _rotationSpeed = 100f; // Sensitivity for mouse rotation
        [SerializeField] private float _smoothTime = 0.1f; // Time for smooth rotation

        private float currentRotationY = 0f;
        private float targetRotationY = 0f;
        private float rotationVelocity; // For smooth damping
        private CinemachineTransposer _transposer;
        private Vector3 _defaultOffset;

        private void Start()
        {
            _transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            _defaultOffset = _transposer.m_FollowOffset;
        }

        void Update()
        {
            if (Input.GetMouseButton(0)) // Right mouse button to rotate
            {
                float mouseX = Input.GetAxis("Mouse X"); // Horizontal mouse movement
                targetRotationY += mouseX * _rotationSpeed * Time.deltaTime * -1f; // Update target rotation
            }

            // Smoothly interpolate current rotation towards target rotation
            currentRotationY = Mathf.SmoothDamp(currentRotationY, targetRotationY, ref rotationVelocity, _smoothTime);

            // Apply rotation to Cinemachine's Follow target
            if (_transposer != null)
            {
                Quaternion rotation = Quaternion.Euler(0, currentRotationY, 0);
                Vector3 newOffset = rotation * new Vector3(0, 0, -_defaultOffset.magnitude);
                _transposer.m_FollowOffset = new Vector3(newOffset.x, _defaultOffset.y, newOffset.z);
            }
        }
    }
}