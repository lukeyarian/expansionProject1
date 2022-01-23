using UnityEngine;

public class InteractableItemWithDialogueWindow : InteractableItemWithDialogue
{
    [SerializeField] private string[] m_TextOnHankerchiefNoFsit;
    [SerializeField] private string[] m_TextOnFsitNoHankerchief;
    [SerializeField] private string[] m_TextsForWantFsit;
    [SerializeField] private string[] m_TextsForWantHankerchief;
    private bool m_DidFinishGame = false;
    private bool m_HasBeenGivenHankerchief;
    private bool m_HasBeenGivenFsit;
    
    public override void Interact()
    {
        bool isNormalWorld = WorldChangeController.Instance.IsNormalWorld;
        StartDialogue(  isNormalWorld? m_DefaultDialogue : GetTextsForFantasyWindow() , true , showOnCat:isNormalWorld);
    }

    private string[] GetTextsForFantasyWindow()
    {
        return m_HasBeenGivenFsit ? m_TextsForWantHankerchief : m_TextsForWantFsit;
    }
    
    public override void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (!EventConditionBooleans.HasInteractedWithWindow || WorldChangeController.Instance.IsNormalWorld)
        {
            DialogueView.Instance.PlayGenericCantDoAnythingDialogue();
            return;
        }
        bool didInteract = false;
        if (incomingItemType == InventoryItemType.FSIT)
        {
            GameEventSystem.Current.RemoveInventoryItem(incomingItemType);
            m_HasBeenGivenFsit = true;
            if (m_HasBeenGivenHankerchief)
            {
                AudioSystem.Instance.PlayWipeWindow();
                didInteract = true;
                StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
                m_DidFinishGame = true;
            }
            else
            {
                didInteract = true;
                StartDialogue(m_TextOnFsitNoHankerchief , false);
            }
        }
        if (incomingItemType == InventoryItemType.PETSETAKI)
        {
            GameEventSystem.Current.RemoveInventoryItem(incomingItemType);
            m_HasBeenGivenHankerchief = true;
            if (m_HasBeenGivenFsit)
            {
                AudioSystem.Instance.PlayWipeWindow();
                didInteract = true;
                StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
                m_DidFinishGame = true;
            }
            else
            {
                didInteract = true;
                StartDialogue(m_TextOnHankerchiefNoFsit , false);
            }
        }

        if (!didInteract)
        {
            DialogueView.Instance.PlayGenericCantDoAnythingDialogue();
        }
    }
    
    protected override void FinishDialogue(bool isDefault)
    {
        base.FinishDialogue(isDefault);
        EventConditionBooleans.HasInteractedWithWindow = true;
        if (m_DidFinishGame)
        {
            Debug.Log("FINISHED GAME");
        }
    }
}