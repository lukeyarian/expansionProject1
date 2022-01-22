using System;
using UnityEngine;

public class InventoryController : SingletonMono<InventoryController>
{
    [SerializeField] private InventoryItemType[] ItemsInInventory;
    [SerializeField] private InventoryItemType m_LastItemClickedOnUI;

    private void Update()
    {
    }
}
