using UnityEngine;

public class InteractableItemWithDialogue : MonoBehaviour , IINteractable
{
    [TextArea]
    public string[] DialogueToShow;

    private BoolVariable m_CanPlayerMove;

    private void Start()
    {
        m_CanPlayerMove = Resources.Load<BoolVariable>("CanPlayerMove");
    }
    
    public void Interact()
    {
        if (DialogueToShow == null || DialogueToShow.Length == 0) return;
        StartDialogue();
    }

    private void StartDialogue()
    {
        m_CanPlayerMove.Value = true;
    }

    private void FinishDialogue()
    {
        m_CanPlayerMove.Value = false;
    }
}
