using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string id;
    public string Name;
    public bool canDrop = false;
    public Sprite icon;
}
