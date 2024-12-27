using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Json_Operations
{
    public class BoneReader
    {
        private string _bonesJson;

        public BoneReader(string bonesJson)
        {
            _bonesJson = bonesJson;
        }
        
        public Transform[] ReadBonesFromFile(Transform rootBone)
        {
            TransformDataList transformDataList = JsonUtility.FromJson<TransformDataList>(_bonesJson);
    
            List<Transform> bones = new List<Transform>();
    
            foreach (TransformData data in transformDataList.transforms)
            {
                Transform bone = FindBoneByName(rootBone, data.name);
                if (bone != null)
                {
                    bone.position = data.position;
                    bone.rotation = data.rotation;
                    bone.localScale = data.scale;
                    bones.Add(bone);
                }
            }
            return bones.ToArray();
        }
    
        private Transform FindBoneByName(Transform root, string name)
        {
            if (root.name == name) return root;
     
            foreach (Transform child in root)
            {
                Transform foundBone = FindBoneByName(child, name);
                if (foundBone != null) 
                    return foundBone;
            }
    
            return null;
        }
    }
}