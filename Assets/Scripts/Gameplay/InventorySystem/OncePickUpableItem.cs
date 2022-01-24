using UnityEngine;

public class OncePickUpableItem : InventoryItem
{
    private bool m_HasAlreadyBeenPickedUp;
    
    public override bool CanBePickedUp()
    {
        if (InventoryItemData.ItemType == InventoryItemType.PETSETAKI && (!EventConditionBooleans.HasFinishedInteractionWithCrystalBall || !WorldChangeController.Instance.IsNormalWorld))
        {
            return false;
        }
        if (InventoryItemData.ItemType == InventoryItemType.FSIT && !WorldChangeController.Instance.IsNormalWorld)
        {
            return false;
        }

        if (InventoryItemData.ItemType == InventoryItemType.SPIDER && (!WorldChangeController.Instance.IsNormalWorld || !EventConditionBooleans .HasFinishedInteractionWithPlant)) 
        {
            return false;
        }
        return !m_HasAlreadyBeenPickedUp;
    }

    public override InventoryItemData PickUpItem()
    {
        Debug.Log("PICK UP " + InventoryItemData.ItemType);
        if (InventoryItemData.ItemType == InventoryItemType.KUVARI)
        {
            DialogueView.Instance.PlayDialogueOnCat(new [] {"Nice tangle ball"} , null);
        }
        m_HasAlreadyBeenPickedUp = true;
        Destroy(gameObject);
        return base.PickUpItem();
    }
}