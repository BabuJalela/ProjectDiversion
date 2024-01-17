using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private Button inventoryItem;
    public Dictionary<string, GameObject> storedObjs = new Dictionary<string, GameObject>();

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    public void AddItem(GameObject objectToStore)
    {
        var item = objectToStore.GetComponent<ItemController>().item;
        items.Add(item);
        storedObjs.Add(item.Name, objectToStore);
        var itemObj = Instantiate(inventoryItem, itemContainer);
        itemObj.GetComponent<InventoryItemController>().item = item;
        var itemImage = itemObj.transform.GetComponent<Image>();
        var itemText = itemObj.GetComponentInChildren<TextMeshProUGUI>();
        if (item.icon)
        {
            itemImage.sprite = item.icon;
        }
        if (item.name != null)
        {
            itemText.SetText(item.name);
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        storedObjs.Remove(item.Name);
    }
}
