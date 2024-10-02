using UnityEngine;

namespace Helper
{
    public class CustomBillboard : MonoBehaviour  // This script is used to make the object always face the camera
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            KeepRotation();
        }
    
        private void KeepRotation()
        {
            Vector3 direction = _camera.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(-rotation.eulerAngles.x, 0, 0);
        }
    }
}
