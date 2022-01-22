public class PizzaItem : InventoryItem
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