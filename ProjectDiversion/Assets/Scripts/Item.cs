using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public List<ItemData> item = new List<ItemData>();
    public Dictionary<string, ItemData> itemDic = new Dictionary<string, ItemData>();

    public Item()
    {
        itemDic = item.ToDictionary(x => x.name, y => y);
    }
}

[System.Serializable]
public class ItemData
{
    public string id;
    public string name;
    public Sprite icon;
}