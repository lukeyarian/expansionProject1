public class ClockItem : InventoryItem
{
    public override bool CanBePickedUp()
    {
        return EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom;
    }
}