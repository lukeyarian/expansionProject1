using System.Collections;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TextMeshPro m_DialogueText;
    [SerializeField] private Transform m_DialogueBox;
    [TextArea]
    [SerializeField] private string[] m_SampleText;
    [SerializeField] private BoolVariable m_IsDialogueOpen;

    private string[] m_TextsToPlay;
    private int m_CurrentTextIndex;
    private bool m_IsAnimatingText;

    private Vector3 m_FullSizeScale;
    [Header("Animation variables")] [SerializeField] private float m_DurationOfScaleUp = 0.2f;
    [Header("Animation variables")] [SerializeField] private Ease m_EaseOfScaleUp = Ease.InBack;
    [Header("Animation variables")] [SerializeField] private Ease m_EaseOfScaleDown = Ease.OutBack;

    [Header("Animation variables")] [SerializeField]
    private float m_DurationOfScaleDown = 0.3f;

    private void Start()
    {
        m_FullSizeScale = m_DialogueBox.lossyScale;
    }  
    
    [Button()]
    private void TestDialogue()
    {
        m_DialogueBox.localScale = Vector3.zero;
        Debug.Log(m_FullSizeScale);
        m_DialogueBox.DOScale(m_FullSizeScale, m_DurationOfScaleUp).SetEase(m_EaseOfScaleUp);
        PlayDialogueText(m_SampleText);
    }

    private void Update()
    {
        if (!m_IsDialogueOpen.Value) return;
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
            m_DialogueBox.DOScale(Vector3.zero, m_DurationOfScaleDown).SetEase(m_EaseOfScaleUp);
            m_IsDialogueOpen.Value = false;
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
        m_DialogueText.text = text;
        m_IsAnimatingText = true;
        int numberOfLetters = text.Length;
        for (int i = 0; i < numberOfLetters; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.03f , 0.04f));
            m_DialogueText.maxVisibleCharacters = i;
        }

        m_IsAnimatingText = false;
        yield return null;
    }
}
