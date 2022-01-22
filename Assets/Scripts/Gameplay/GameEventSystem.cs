using System;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem Current;

    private void Awake()
    {
        Current = this;
    }

    public event Action<InventoryItemData> OnAddItemToInventory;

    public void AddItemToPlayerInventory(InventoryItemData inventoryItemType)
    {
        OnAddItemToInventory?.Invoke(inventoryItemType);
    }
    
    public event Action<InventoryItemType> OnRemoveInventoryItem;

    public void RemoveInventoryItem(InventoryItemType inventoryItemType)
    {
        OnRemoveInventoryItem?.Invoke(inventoryItemType);
    }
    
    public event Action<InventoryItemData> OnSetCurrentlySelectedInventoryItem;

    public void SetCurrentlySelectedInventoryItem(InventoryItemData inventoryItemType)
    {
        OnSetCurrentlySelectedInventoryItem?.Invoke(inventoryItemType);
    }
}
