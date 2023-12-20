using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectAddressables : MonoBehaviour
{

    [SerializeField] private LevelDataScriptableObject levelData;
    [SerializeField] private GameObject sceneHandler;
    private static Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();
    private int spawnedCount = 0;
    private bool isHandlerActive = false;

    private void Awake()
    {
        levelData.ConvertToDictionary();
        foreach (var obj in levelData.data)
        {
            InstantiateAsset(obj.Key);
        }
    }

    private void Update()
    {
        if (spawnedCount == levelData.data.Count && !isHandlerActive)
        {
            sceneHandler.SetActive(true);
            isHandlerActive = true;
        }
    }

    private void InstantiateAsset(string id)
    {
        levelData.data[id].levelObjects.InstantiateAsync().Completed += (asyncOperation) =>
        {
            spawnedCount++;
            spawnedObjects.Add(levelData.data[id].ObjectId, asyncOperation.Result);
        };
    }

    public static GameObject GetLevelDatathroughID(string ObjectID)
    {
        if (spawnedObjects.ContainsKey(ObjectID))
        {
            return spawnedObjects[ObjectID];
        }
        return null;
    }

}
