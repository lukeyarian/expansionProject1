using UnityEngine;

public class InteractableItemWithDialogueDoor : InteractableItemWithDialogue 
{
    [SerializeField] private BoxCollider2D m_ColliderToDestroyToAllowPlayerToMove;
    private bool m_DidInteractWithClock = false;
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        if (isDefault && !WorldChangeController.Instance.IsNormalWorld)
        {
            EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom = true;
        }
        else
        {
            if (m_DidInteractWithClock)
            {
                m_ColliderToDestroyToAllowPlayerToMove.enabled = false;
            }
        }
    }

    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
        if(incomingItemType.Equals(InventoryItemType.CLOCK) && !WorldChangeController.Instance.IsNormalWorld)
        {
            AudioSystem.Instance.PlayAlarm();
            EventConditionBooleans.HasUsedTheClock = true;
            GameEventSystem.Current.RemoveInventoryItem(incomingItemType);
            m_DidInteractWithClock = true;
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
        }
        else
        {
            DialogueView.Instance.PlayGenericCantDoAnythingDialogue();
        }
    }
}