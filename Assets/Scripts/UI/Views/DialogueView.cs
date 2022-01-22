using System.Collections;
using System.Text;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_DialogueText;
    
    [SerializeField] private string m_SampleText;

    [Button()]
    private void TestDialogue()
    {
        PlayDialogueText(m_SampleText);
    }
    
    public void PlayDialogueText(string text)
    {
        m_DialogueText.text = string.Empty;
        StartCoroutine(TypeMachineText(text));
    }

    private IEnumerator TypeMachineText(string text)
    {
        int numberOfLetters = text.Length;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < numberOfLetters; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.03f , 0.04f));
            sb.Append(text[i]);
            m_DialogueText.text = sb.ToString();
        }
        yield return null;
    }
}
