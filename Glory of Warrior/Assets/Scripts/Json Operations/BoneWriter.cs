using System.IO;
using Helper;
using UnityEditor;
using UnityEngine;

namespace Json_Operations
{
    public class BoneWriter: MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _renderer; // The character model's SkinnedMeshRenderer component that contains the bones to save.
        [SerializeField] private BoneStorageSO _boneStorageSO;

        private void Start()
        {
            WriteBonesToStorage(_renderer);
        }

        private void WriteBonesToStorage(SkinnedMeshRenderer renderer)
        {
            TransformDataList transformDataList = new TransformDataList();
    
            foreach (Transform bone in renderer.bones)
            {
                transformDataList.transforms.Add(new TransformData(bone));
            }
    
            // Convert the data to JSON format and write into file.
            string json = JsonUtility.ToJson(transformDataList, true);
            _boneStorageSO.setBonesJson(json);
         //   EditorUtility.SetDirty(_boneStorageSO);
        }
    }
}