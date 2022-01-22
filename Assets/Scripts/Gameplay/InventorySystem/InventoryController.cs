using UnityEngine;

public class InventoryController : SingletonMono<InventoryController>
{
    [SerializeField] private InventoryItemType[] ItemsInInventory;
    [SerializeField] private InventoryItemType m_LastItemClickedOnUI;
    [SerializeField] private BoolVariable m_IsShowingDialogue;

    private void Update()
    {
        if (m_IsShowingDialogue.Value) return;
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
