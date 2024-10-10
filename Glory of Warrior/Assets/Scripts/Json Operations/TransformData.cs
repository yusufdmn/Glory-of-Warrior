using System.Collections.Generic;
using UnityEngine;

namespace Json_Operations
{ 
[System.Serializable]
public class TransformData
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public TransformData(Transform transform)
    {
        name = transform.name;
        position = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;
    }
}

[System.Serializable]
public class TransformDataList
{
    public List<TransformData> transforms = new List<TransformData>();
}

}