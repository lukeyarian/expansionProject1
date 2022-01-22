using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_DialogueText;

    public void PlayDialogueText(string text)
    {
        m_DialogueText.text = string.Empty;
    }

    private IEnumerator TypeMachineText(string text)
    {
        int numberOfLetters = text.Length;
        yield return null;
    }
}
