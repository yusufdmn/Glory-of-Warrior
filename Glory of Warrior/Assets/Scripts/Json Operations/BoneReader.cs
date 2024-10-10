using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Json_Operations
{
    public class BoneReader
    {
        private string filePath = "Assets/Scripts/Json Operations/Json Files/Bones.json";
    
        public Transform[] ReadBonesFromFile(Transform rootBone)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
    
            string json = File.ReadAllText(filePath);
            TransformDataList transformDataList = JsonUtility.FromJson<TransformDataList>(json);
    
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