public class InteractableItemWithDialogueSpider : InteractableItemWithDialogue 
{
    public override void Interact()
    {
        if (!EventConditionBooleans.HasFinishedInteractionWithPlant) return;
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true);
    }
    
    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (!EventConditionBooleans.HasInteractedWithWindow || !WorldChangeController.Instance.IsNormalWorld) return;
        if (incomingItemType == InventoryItemType.PIZZA)
        {
            //StartDialogue(m_SpiderDialogue , false);
        }
        if (incomingItemType == InventoryItemType.SPIDER)
        {
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
        }
    }
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        EventConditionBooleans.HasFinishedInteractionWithPlant = true;
    }
}