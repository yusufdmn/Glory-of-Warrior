using Json_Operations;
using UnityEngine;

namespace Helper
{
    public class BoneStorage: MonoBehaviour // This class is used to get the bones of the character model.
    {
        [SerializeField] private Transform _rootBone;
        [SerializeField] private BoneStorageSO _boneStorage;

        private Transform[] _bones;
        private BoneReader _boneReader;
        public Transform RootBone => _rootBone;
        public Transform[] Bones => _bones;

        private void Awake()
        {
            _boneReader = new BoneReader(_boneStorage.getBonesJson());
            _bones = _boneReader.ReadBonesFromFile(_rootBone);
        }
    }
}