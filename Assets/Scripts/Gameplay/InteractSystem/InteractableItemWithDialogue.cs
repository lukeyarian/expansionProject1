using UnityEngine;

public class InteractableItemWithDialogue : MonoBehaviour , IINteractable
{
    [TextArea]
    [SerializeField] protected string[] m_DefaultDialogue;
    [SerializeField] protected string[] m_FantasyDialogue;
    [SerializeField] protected string[] m_SpecialDialoguesForInteractSuccessful;
    
    [SerializeField] protected InventoryItemType m_ItemItWantsForInteract;
    [SerializeField] protected InventoryItemData m_InventoryItemThisCharacterCanGive;
    [SerializeField] protected bool m_ItemShouldBeGivenOnDefaultDialogue;
    
    protected BoolVariable m_CanPlayerMove;
    protected BoolVariable m_DialogueIsShowing;
    public bool ShouldShowSpecialInteractDialogueOnCat = true;
    public bool ShouldShowRealWorldInteractOnCat = true;

    private void Start()
    {
        m_CanPlayerMove = Resources.Load<BoolVariable>("CanPlayerMove");
        m_DialogueIsShowing = Resources.Load<BoolVariable>("IsDialogueOpen");
    }
    
    public virtual void Interact()
    {
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true , WorldChangeController.Instance.IsNormalWorld);
    }

    public virtual void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (incomingItemType == m_ItemItWantsForInteract && incomingItemType != InventoryItemType.NONE)
        {
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false , WorldChangeController.Instance.IsNormalWorld);
        }
    }

    protected void StartDialogue(string[] dialogueToUse , bool isDefault , bool showOnCat = false)
    {
        Debug.Log("START DIALOGUE");
        if (dialogueToUse == null || dialogueToUse.Length == 0 ||  m_DialogueIsShowing.Value) return;
        m_CanPlayerMove.Value = false;
        if (showOnCat)
        {
            DialogueView.Instance.PlayDialogueOnCat(dialogueToUse, ()=>FinishDialogue(isDefault));
        }
        else
        {
            DialogueView.Instance.PlayDialogueText(dialogueToUse, ()=>FinishDialogue(isDefault) , transform.position);
        }
    }

    protected virtual void FinishDialogue(bool isDefault)
    {
        m_CanPlayerMove.Value = true;
        if (m_InventoryItemThisCharacterCanGive != null && m_ItemShouldBeGivenOnDefaultDialogue == isDefault)
        {
            GameEventSystem.Current.AddItemToPlayerInventory(m_InventoryItemThisCharacterCanGive);
        }
    }
}