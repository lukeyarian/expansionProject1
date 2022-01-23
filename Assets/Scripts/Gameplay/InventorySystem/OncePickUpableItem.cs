public class OncePickUpableItem : InventoryItem
{
    private bool m_HasAlreadyBeenPickedUp;
    
    public override bool CanBePickedUp()
    {
        return !m_HasAlreadyBeenPickedUp;
    }

    public override InventoryItemData PickUpItem()
    {
        m_HasAlreadyBeenPickedUp = true;
        return base.PickUpItem();
    }
}