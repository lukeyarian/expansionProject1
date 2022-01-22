using UnityEngine;

public enum InventoryItemType
{
    NONE,
    CLOCK,
    PIZZA
}

public interface PickUpAble
{
    bool CanBePickedUp();
    InventoryItemData ItemData { get; }
}

public abstract class InventoryItem : MonoBehaviour , PickUpAble
{
    public InventoryItemData InventoryItemData;

    public abstract bool CanBePickedUp();
    public InventoryItemData ItemData => InventoryItemData;
}