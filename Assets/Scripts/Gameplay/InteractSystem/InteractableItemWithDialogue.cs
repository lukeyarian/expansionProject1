using UnityEngine;

public class InteractableItemWithDialogue : MonoBehaviour , IINteractable
{
    [TextArea]
    [SerializeField] private string[] m_DefaultDialogue;
    [SerializeField] private string[] m_SpecialDialoguesForInteractSuccessful;
    [SerializeField] private InventoryItemType m_ItemItWantsForInteract;
    
    private BoolVariable m_CanPlayerMove;
    private BoolVariable m_DialogueIsShowing;

    private void Start()
    {
        m_CanPlayerMove = Resources.Load<BoolVariable>("CanPlayerMove");
        m_DialogueIsShowing = Resources.Load<BoolVariable>("IsDialogueOpen");
    }
    
    public void Interact()
    {
        StartDialogue(m_DefaultDialogue);
    }

    public void InteractWithItem(InventoryItemType incomingItemType)
    {
        if (incomingItemType == m_ItemItWantsForInteract && incomingItemType != InventoryItemType.NONE)
        {
            StartDialogue(m_SpecialDialoguesForInteractSuccessful);
        }
    }

    private void StartDialogue(string[] dialogueToUse)
    {
        if (m_DefaultDialogue == null || m_DefaultDialogue.Length == 0 ||  m_DialogueIsShowing.Value) return;
        m_CanPlayerMove.Value = false;
        DialogueView.Instance.PlayDialogueText(dialogueToUse, FinishDialogue , transform.position);
    }

    private void FinishDialogue()
    {
        m_CanPlayerMove.Value = true;
    }
}