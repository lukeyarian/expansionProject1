using System.Collections;
using System.Text;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_DialogueText;
    [SerializeField] private Transform m_DialogueBox;
    [TextArea]
    [SerializeField] private string[] m_SampleText;
    [SerializeField] private BoolVariable m_IsDialogueOpen;

    private string[] m_TextsToPlay;
    private int m_CurrentTextIndex;
    private bool m_IsAnimatingText;
    
    [Button()]
    private void TestDialogue()
    {
        /*
    public static Tweener DOShakeScale(
      this Transform target,
      float duration,
      Vector3 strength,
      int vibrato = 10,
      float randomness = 90f,
      bool fadeOut = true)
      */
        m_DialogueBox.localScale = new Vector3(11f, 11f, 11f);
        m_DialogueBox.DOShakeScale(0.3f, new Vector3(30, 30, 30), 1);
        PlayDialogueText(m_SampleText);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToNextPartInDialogue();
        }
    }

    private void MoveToNextPartInDialogue()
    {
        if (m_IsAnimatingText)
        {
            StopAllCoroutines();
        }

        m_CurrentTextIndex++;
        if (m_CurrentTextIndex >= m_TextsToPlay.Length)
        {
            Debug.Log("STOP DIALOGUE");
            return;
        }
        StartCoroutine(TypeMachineText(m_TextsToPlay[m_CurrentTextIndex]));
    }

    public void PlayDialogueText(string[] text)
    {
        m_CurrentTextIndex = 0;
        m_TextsToPlay = text;
        m_IsDialogueOpen.Value = true;
        m_DialogueText.text = string.Empty;
        StartCoroutine(TypeMachineText(text[m_CurrentTextIndex]));
    }

    private IEnumerator TypeMachineText(string text)
    {
        m_DialogueText.text = string.Empty;
        m_IsAnimatingText = true;
        int numberOfLetters = text.Length;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < numberOfLetters; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.03f , 0.04f));
            sb.Append(text[i]);
            m_DialogueText.text = sb.ToString();
        }

        m_IsAnimatingText = false;
        yield return null;
    }
}
