using UnityEngine;

namespace Gameplay_System
{
    public class AudioPlayer : MonoBehaviour
    {
        #region Singleton
        private static AudioPlayer _instance;
        public static AudioPlayer Instance => _instance;

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        #endregion

        private bool _isMuted = false;
        public void playSound(AudioSource audioSource)
        {
            if (_isMuted)
                return;
            audioSource.Play();
        }
    }
}
