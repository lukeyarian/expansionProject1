public class InteractableItemWithDialogueCrystalBall : InteractableItemWithDialogue 
{
    public override void Interact()
    {
        if (!EventConditionBooleans.HasFinishedInteractionWithPlant) return;
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true);
    }
    
    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
    }
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
    }
}