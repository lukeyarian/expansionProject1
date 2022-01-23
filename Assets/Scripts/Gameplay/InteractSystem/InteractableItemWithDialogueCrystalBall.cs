public class InteractableItemWithDialogueCrystalBall : InteractableItemWithDialogue 
{
    public override void Interact()
    {
        if (!EventConditionBooleans.HasGivenSpiderToPlant || WorldChangeController.Instance.IsNormalWorld) return;
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true);
    }
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        EventConditionBooleans.HasFinishedInteractionWithCrystalBall = true;
    }
}