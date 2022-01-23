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
        if (InventoryItemData.ItemType == InventoryItemType.KUVARI)
        {
            DialogueView.Instance.PlayDialogueOnCat(new [] {"Nice tangle ball"} , null);
        }
        m_HasAlreadyBeenPickedUp = true;
        Destroy(gameObject);
        return base.PickUpItem();
    }
}