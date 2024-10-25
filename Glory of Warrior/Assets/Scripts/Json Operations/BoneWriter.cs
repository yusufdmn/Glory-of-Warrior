using System.IO;
using UnityEngine;

namespace Json_Operations
{
    public class BoneWriter: MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _renderer;
        [SerializeField] private string _fileName;
        private string _filePath;

        private void Start()
        {
            _filePath = Path.Combine(Application.streamingAssetsPath, _fileName);
            WriteBonesToFile(_renderer);
        }

        private void WriteBonesToFile(SkinnedMeshRenderer renderer)
        {
            TransformDataList transformDataList = new TransformDataList();
    
            foreach (Transform bone in renderer.bones)
            {
                transformDataList.transforms.Add(new TransformData(bone));
            }
    
            // Convert the data to JSON format and write into file.
            string json = JsonUtility.ToJson(transformDataList, true);
            File.WriteAllText(_filePath, json);
        }
    }
}