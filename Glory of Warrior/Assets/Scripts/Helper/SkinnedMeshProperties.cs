using Inventory_System.View.Helper;
using UnityEngine;
using Zenject;

namespace Helper
{
    public class SkinnedMeshProperties: MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private Material _material;
        [SerializeField] private Mesh _mesh;
        [Inject] private BoneStorage _boneStorage;
        
        void Start()
        {
            _skinnedMeshRenderer.sharedMaterial = _material;
            _skinnedMeshRenderer.sharedMesh = _mesh;
            _skinnedMeshRenderer.bones = _boneStorage.Bones;
            _skinnedMeshRenderer.rootBone = _boneStorage.RootBone;
        }
    
    }
}