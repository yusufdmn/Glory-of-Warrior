using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay_System.Helper
{
    public class InputData: MonoBehaviour // Temporary Input System
    {
        public Vector3 MoveDirection { get; private set; } = Vector3.zero;

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            MoveDirection = new Vector3(x, 0, z);
        }
    }
}