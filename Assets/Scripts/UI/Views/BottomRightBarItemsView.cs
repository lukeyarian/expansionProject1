using System.Collections.Generic;
using UnityEngine;

public class BottomRightBarItemsView : MonoBehaviour
{
    [SerializeField] private Transform m_ParentLayoutTransform;
    [SerializeField] private GameObject m_PrefabOfItem;

    private Dictionary<InventoryItemType, GameObject>
        m_ItemTypeToView = new Dictionary<InventoryItemType, GameObject>();

    private void Start()
    {
        GameEventSystem.Current.OnAddItemToInventory += AddItemOnView;
    }

    private void AddItemOnView(InventoryItemData inventoryItem)
    {
        var instantiatedView = Instantiate(m_PrefabOfItem, m_ParentLayoutTransform);
        m_ItemTypeToView.Add(inventoryItem.ItemType, instantiatedView);
        var viewOfItem = instantiatedView.GetComponent<PickedUpItemView>();
        viewOfItem.SetView(inventoryItem.ItemImageOnUI , ()=>GameEventSystem.Current.SetCurrentlySelectedInventoryItem(inventoryItem.ItemType));
    }
}
