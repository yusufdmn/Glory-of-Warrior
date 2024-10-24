using UnityEngine;
using Cinemachine;


namespace Helper
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera _virtualCamera;
        void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _virtualCamera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            _virtualCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        }

    
    }
}
