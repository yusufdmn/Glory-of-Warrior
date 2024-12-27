using UnityEngine;

namespace Helper
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform followedPlayer;
        [SerializeField] private float smoothDamp = 0.15f;
        [SerializeField] private Vector3 offset;
        Vector3 velocity = Vector3.zero;

        private void Start()
        {
            followedPlayer = GameObject.FindWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            Vector3 targetPos = followedPlayer.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothDamp * Time.deltaTime);
            // make rotation same as the target
            Vector3 newRotation = new Vector3(90, followedPlayer.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Euler(newRotation);

        }

    }
}