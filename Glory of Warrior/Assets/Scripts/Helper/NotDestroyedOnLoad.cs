using UnityEngine;

namespace Helper
{
    public class NotDestroyedOnLoad : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}