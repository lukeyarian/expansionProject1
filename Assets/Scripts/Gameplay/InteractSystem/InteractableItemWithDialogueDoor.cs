using UnityEngine;

public class InteractableItemWithDialogueDoor : InteractableItemWithDialogue
{
    protected override void FinishDialogue(bool isDefault)
    {
        Debug.Log("IS HAPPENING");
        base.FinishDialogue(isDefault);
        EventConditionBooleans.HasUserTalkedToDoorOnFirstRoom = true;
    }
}