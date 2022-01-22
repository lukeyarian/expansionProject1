using UnityEngine;

public interface IINteractable
{
    void Interact();
    void InteractWithItem(InventoryItemType incomingItemType);
}
