using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] private Button itemClickButton;
    [HideInInspector] public Item item;
    private void Start()
    {
        itemClickButton.onClick.AddListener(() =>
        {
            switch (item.Name)
            {
                case "Cloth":
                    Debug.Log("this is cloth");
                    break;

                case "Key":
                    Debug.Log("this is Key");
                    break;
            }
        });
    }
    public void RemoveItem()
    {
        InventoryManager.instance.RemoveItem(item);
        Destroy(this.gameObject);
    }
}
