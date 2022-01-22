public class ClockItem : InventoryItem
{
    private bool m_HasAlreadyBeenPickedUp = false;
    
    
    public override bool CanBePickedUp()
    {
        return EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom && !EventConditionBooleans.HasUsedTheClock && !m_HasAlreadyBeenPickedUp;
    }

    public override InventoryItemData PickUpItem()
    {
        m_HasAlreadyBeenPickedUp = true;
        return base.PickUpItem();
    }
}