using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helper
{
    public class CustomBillboard : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void LateUpdate()
        {
            KeepRotation();
        }

        private void KeepRotation()
        {
            if (_camera == null) 
            {
                _camera = Camera.main; 
                return; 
            }

            Vector3 direction = _camera.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0); 
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _camera = Camera.main;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}