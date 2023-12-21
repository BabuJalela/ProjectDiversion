using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu]
public class LevelDataScriptableObject : ScriptableObject
{
    public string levelID;
    public List<LevelData> levelDataHolders = new List<LevelData>();
    public Dictionary<string, LevelData> data = new Dictionary<string, LevelData>();

    public void ConvertToDictionary()
    {
        data = levelDataHolders.ToDictionary(x => x.ObjectId, y => y);
    }
}

[System.Serializable]
public class LevelData
{
    public string ObjectId;
    public AssetReferenceGameObject levelObjects;
}

//[System.Serializable]
//public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
//{
//    public AssetReferenceAudioClip(string guid) : base(guid) { }
//}
