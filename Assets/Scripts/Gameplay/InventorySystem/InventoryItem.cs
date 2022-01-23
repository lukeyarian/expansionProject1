using UnityEngine;

public enum InventoryItemType
{
    NONE,
    CLOCK,
    PIZZA,
    SPIDER,
    FSIT,
    PETSETAKI,
}

public interface PickUpAble
{
    bool CanBePickedUp();
    InventoryItemData PickUpItem();
}

public abstract class InventoryItem : MonoBehaviour , PickUpAble
{
    public InventoryItemData InventoryItemData;

    public abstract bool CanBePickedUp();
    public virtual InventoryItemData PickUpItem()
    {
        return InventoryItemData;
    }
}