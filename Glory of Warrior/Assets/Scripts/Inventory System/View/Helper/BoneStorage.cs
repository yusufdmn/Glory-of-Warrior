using Json_Operations;
using UnityEngine;

namespace Inventory_System.View.Helper
{
    public class BoneStorage: MonoBehaviour // This class is used to get the bones of the character model.
    {
        [SerializeField] private Transform _rootBone;
        private Transform[] _bones;
        private BoneReader _boneReader;
        public Transform RootBone => _rootBone;
        public Transform[] Bones => _bones;

        private void Awake()
        {
            _boneReader = new BoneReader();
            _bones = _boneReader.ReadBonesFromFile(_rootBone);
        }
    }
}