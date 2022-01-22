using UnityEngine;

public class InteractableItemWithDialogue : MonoBehaviour , IINteractable
{
    [TextArea]
    [SerializeField] private string[] m_DialogueToShow;
    private BoolVariable m_CanPlayerMove;
    private BoolVariable m_DialogueIsShowing;

    private void Start()
    {
        m_CanPlayerMove = Resources.Load<BoolVariable>("CanPlayerMove");
        m_DialogueIsShowing = Resources.Load<BoolVariable>("IsDialogueOpen");
    }
    
    public void Interact()
    {
        if (m_DialogueToShow == null || m_DialogueToShow.Length == 0 ||  m_DialogueIsShowing.Value) return;
        StartDialogue();
    }

    private void StartDialogue()
    {
        m_CanPlayerMove.Value = false;
        DialogueView.Instance.PlayDialogueText(m_DialogueToShow, FinishDialogue , transform.position);
    }

    private void FinishDialogue()
    {
        m_CanPlayerMove.Value = true;
    }
}