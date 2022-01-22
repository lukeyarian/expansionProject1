using UnityEngine;

public class InteractableItemWithDialogue : MonoBehaviour , IINteractable
{
    [TextArea]
    [SerializeField] private string[] m_DefaultDialogue;
    [SerializeField] private string[] m_FantasyDialogue;
    [SerializeField] protected string[] m_SpecialDialoguesForInteractSuccessful;
    
    [SerializeField] private InventoryItemType m_ItemItWantsForInteract;
    [SerializeField] private InventoryItemData m_InventoryItemThisCharacterCanGive;
    [SerializeField] private bool m_ItemShouldBeGivenOnDefaultDialogue;
    
    private BoolVariable m_CanPlayerMove;
    private BoolVariable m_DialogueIsShowing;

    private void Start()
    {
        m_CanPlayerMove = Resources.Load<BoolVariable>("CanPlayerMove");
        m_DialogueIsShowing = Resources.Load<BoolVariable>("IsDialogueOpen");
    }
    
    public void Interact()
    {
        StartDialogue(WorldChangeController.Instance.IsNormalWorld? m_DefaultDialogue : m_FantasyDialogue , true);
    }

    public virtual void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (incomingItemType == m_ItemItWantsForInteract && incomingItemType != InventoryItemType.NONE)
        {
            StartDialogue(m_SpecialDialoguesForInteractSuccessful , false);
        }
    }

    protected void StartDialogue(string[] dialogueToUse , bool isDefault)
    {
        Debug.Log("START DIALOGUE");
        if (dialogueToUse == null || dialogueToUse.Length == 0 ||  m_DialogueIsShowing.Value) return;
        m_CanPlayerMove.Value = false;
        DialogueView.Instance.PlayDialogueText(dialogueToUse, ()=>FinishDialogue(isDefault) , transform.position);
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