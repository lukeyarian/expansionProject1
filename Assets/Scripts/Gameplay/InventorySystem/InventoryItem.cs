using UnityEngine;

public enum InventoryItemType
{
    NONE,
    CLOCK,
    PIZZA
}

public interface IPickable
{
    bool CanBePickedUp();
    InventoryItemType TypeOfItem { get; }
}

public abstract class InventoryItem : MonoBehaviour , IPickable
{
    public InventoryItemType InventoryItemType;
    public InventoryItemType TypeOfItem => InventoryItemType;

    public abstract bool CanBePickedUp();
}

public class ClockItem : InventoryItem
{
    public override bool CanBePickedUp()
    {
        return EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom;
    }
}
