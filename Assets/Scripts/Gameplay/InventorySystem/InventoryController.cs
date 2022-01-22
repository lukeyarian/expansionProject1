using System.Collections.Generic;
using UnityEngine;

public class InventoryController : SingletonMono<InventoryController>
{
    [SerializeField] private List<InventoryItemType> m_ItemsInInventory = new List<InventoryItemType>();
    [SerializeField] private InventoryItemType m_LastItemClickedOnUI;
    [SerializeField] private BoolVariable m_IsShowingDialogue;

    private void Start()
    {
        GameEventSystem.Current.OnAddItemToInventory += AddItemToInventory;
    }

    private void AddItemToInventory(InventoryItemData inventoryItemData)
    {
        GiveItemToPlayer(inventoryItemData.ItemType);
    }

    public void GiveItemToPlayer(InventoryItemType item)
    {
        m_ItemsInInventory.Add(item);
    }
}
