using UnityEngine;

public class OncePickUpableItem : InventoryItem
{
    private bool m_HasAlreadyBeenPickedUp;
    
    public override bool CanBePickedUp()
    {
        if (InventoryItemData.ItemType == InventoryItemType.PETSETAKI && !EventConditionBooleans.HasFinishedInteractionWithPlant)
        {
            return false;
        }
        Debug.Log(EventConditionBooleans.HasFinishedInteractionWithPlant);
        if (InventoryItemData.ItemType == InventoryItemType.SPIDER && !EventConditionBooleans.HasFinishedInteractionWithPlant)
        {
            return false;
        }
        return !m_HasAlreadyBeenPickedUp;
    }

    public override InventoryItemData PickUpItem()
    {
        m_HasAlreadyBeenPickedUp = true;
        return base.PickUpItem();
    }
}