using UnityEngine;

public class InteractableItemWithDialoguePlant : InteractableItemWithDialogue 
{
    [SerializeField] protected string[] m_DialoguesForPizza;
    
    public override void Interact()
    {
        if (!EventConditionBooleans.HasInteractedWithWindow) return;
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true);
    }
    
    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (!EventConditionBooleans.HasInteractedWithWindow || WorldChangeController.Instance.IsNormalWorld) return;
        if (incomingItemType == InventoryItemType.PIZZA)
        {
            AudioSystem.Instance.PlayEatPlant();
            StartDialogue(m_DialoguesForPizza , false);
        }
        if (incomingItemType == InventoryItemType.SPIDER)
        {
            AudioSystem.Instance.PlayEatPlant();
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
            EventConditionBooleans.HasGivenSpiderToPlant = true;
        }
    }
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        EventConditionBooleans.HasFinishedInteractionWithPlant = true;
    }
}