using Inventory_System.View.Helper;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helper
{
    [RequireComponent(typeof(BoneStorage))]
    public class SkinnedMeshCombiner : MonoBehaviour
    {
        private SkinnedMeshRenderer[] _skinnedMeshRenderers;
        private List<CombineInstance> _combineInstances;
        private List<Transform> _bones;
        private List<Matrix4x4> _bindPoses;
        private List<BoneWeight> _boneWeights;
        private BoneStorage _boneStorage;
        private Material _sharedMaterial;
        private SkinnedMeshRenderer _outputSkinnedMeshRenderer;
        private Mesh _combinedMesh;

        private async void Start()
        {
            _boneStorage = GetComponent<BoneStorage>();
            _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            _combineInstances = new List<CombineInstance>();
            _bones = new List<Transform>();
            _bindPoses = new List<Matrix4x4>();
            _boneWeights = new List<BoneWeight>();

            _sharedMaterial = _skinnedMeshRenderers[0].sharedMaterial;
            await CombineSkinnedMeshes();
            
            // Assign the combined mesh and bones to the output SkinnedMeshRenderer
            _outputSkinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
            _outputSkinnedMeshRenderer.sharedMesh = _combinedMesh;
            _outputSkinnedMeshRenderer.sharedMaterial = _sharedMaterial;
            _outputSkinnedMeshRenderer.bones = _bones.ToArray();
            _outputSkinnedMeshRenderer.rootBone = _boneStorage.RootBone;
            _outputSkinnedMeshRenderer.sharedMesh.bindposes = _bindPoses.ToArray();
        }

        private Task CombineSkinnedMeshes()
        {
            int boneOffset = 0;

            foreach (var skinnedMeshRenderer in _skinnedMeshRenderers)
            {
                // Combine the mesh data
                CombineInstance combineInstance = new CombineInstance
                {
                    mesh = skinnedMeshRenderer.sharedMesh,
                    transform = skinnedMeshRenderer.transform.localToWorldMatrix
                };
                _combineInstances.Add(combineInstance);
                
                // Store bone weights
                BoneWeight[] meshBoneWeights = skinnedMeshRenderer.sharedMesh.boneWeights;
                foreach (BoneWeight boneWeight in meshBoneWeights)
                {
                    BoneWeight newBoneWeight = boneWeight;
                    newBoneWeight.boneIndex0 += boneOffset;
                    newBoneWeight.boneIndex1 += boneOffset;
                    newBoneWeight.boneIndex2 += boneOffset;
                    newBoneWeight.boneIndex3 += boneOffset;
                    _boneWeights.Add(newBoneWeight);
                }
                
                // Store the bones and their bind poses
                _bones.AddRange(skinnedMeshRenderer.bones);
                _bindPoses.AddRange(skinnedMeshRenderer.sharedMesh.bindposes);
                boneOffset += skinnedMeshRenderer.bones.Length;
                
                // Deactivate the original renderer
                skinnedMeshRenderer.gameObject.SetActive(false);
            }
            _combinedMesh = new Mesh();
            _combinedMesh.CombineMeshes(_combineInstances.ToArray(), true, false);
            _combinedMesh.boneWeights = _boneWeights.ToArray();
            return Task.CompletedTask;
        }
    }
}