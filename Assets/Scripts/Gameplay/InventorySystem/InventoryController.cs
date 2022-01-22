using System.Collections.Generic;
using UnityEngine;

public class InventoryController : SingletonMono<InventoryController>
{
    [SerializeField] private List<InventoryItemType> m_ItemsInInventory = new List<InventoryItemType>();
    public InventoryItemData LastItemClickedOnUI;
    [SerializeField] private BoolVariable m_IsShowingDialogue;

    private void Start()
    {
        GameEventSystem.Current.OnAddItemToInventory += AddItemToInventory;
        GameEventSystem.Current.OnRemoveInventoryItem += RemoveItemFromInventory;
        GameEventSystem.Current.OnSetCurrentlySelectedInventoryItem += item =>LastItemClickedOnUI = item;
    }

    private void AddItemToInventory(InventoryItemData inventoryItemData)
    {
        GiveItemToPlayer(inventoryItemData.ItemType);
    }
    
    private void RemoveItemFromInventory(InventoryItemType inventoryItemData)
    {
        m_ItemsInInventory.Remove(inventoryItemData);
    }

    public void GiveItemToPlayer(InventoryItemType item)
    {
        m_ItemsInInventory.Add(item);
    }
}
