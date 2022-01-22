using UnityEngine;

public class InteractableItemWithDialogueDoor : InteractableItemWithDialogue 
{
    [SerializeField] private BoxCollider2D m_ColliderToDestroyToAllowPlayerToMove;
    private bool m_DidInteractWithClock = false;
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        Debug.Log("Finish dialogue of door");
        if (isDefault && !WorldChangeController.Instance.IsNormalWorld)
        {
            Debug.Log("Finish dialogue of door on normal world");
            EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom = true;
        }
        else
        {
            Debug.Log("Finish dialogue of door on fake world and did interact: " + m_DidInteractWithClock);
            if (m_DidInteractWithClock)
            {
                m_ColliderToDestroyToAllowPlayerToMove.enabled = false;
            }
        }
    }

    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
        if(incomingItemType.Equals(InventoryItemType.CLOCK))
        {
            m_DidInteractWithClock = true;
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
        }
    }
}