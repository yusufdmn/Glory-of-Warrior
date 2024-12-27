using Cinemachine;
using UnityEngine;

namespace Gameplay_System.Helper
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VirtualCameraHelper: MonoBehaviour
    {
        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
                virtualCamera.Follow = player.transform;
                virtualCamera.LookAt = player.transform;
            }
        }
    }
}