using UnityEngine;

[CreateAssetMenu(menuName = "InventoryItemData", fileName = "InventoryItemData", order = 0)]
public class InventoryItemData : ScriptableObject
{
    public InventoryItemType ItemType;
    public Sprite ItemImageOnUI;
}
