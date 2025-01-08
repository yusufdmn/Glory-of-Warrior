using UnityEngine;

namespace Helper
{
    public class CursorSettings: MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorTexture;
        [SerializeField] private Vector2 _hotspot = Vector2.zero;
        
        void Start()
        {
            Cursor.SetCursor(_cursorTexture, _hotspot, CursorMode.Auto);
        }
        
    }
}