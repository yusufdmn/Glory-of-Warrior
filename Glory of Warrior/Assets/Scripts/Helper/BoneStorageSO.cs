using UnityEngine;

namespace Helper
{
    [CreateAssetMenu(fileName = "BoneStorage", menuName = "Bones/BoneStorage")]
    public class BoneStorageSO : ScriptableObject
    {
        [SerializeField] private string _bonesJson; // json string that contains the bones of the character model.

        public string getBonesJson()
        {
            return _bonesJson;
        }

        public void setBonesJson(string bonesJson)
        {
            Debug.Log(" bonesJson is updated, the updated instance is: " + this.GetInstanceID());
            
            _bonesJson = bonesJson;
            
        }
    }
}