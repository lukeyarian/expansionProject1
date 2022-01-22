using System;
using System.Collections;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueView : SingletonMono<DialogueView>
{
    [SerializeField] private TextMeshPro m_DialogueText;
    [SerializeField] private Transform m_DialogueBox;
    [TextArea]
    [SerializeField] private string[] m_SampleText;
    [SerializeField] private BoolVariable m_IsDialogueOpen;

    private Vector3 m_FullSizeScale;
    [Header("Animation variables")] [SerializeField] private float m_DurationOfScaleUp = 0.2f;
     [SerializeField] private Ease m_EaseOfScaleUp = Ease.InBack;
     [SerializeField] private Ease m_EaseOfScaleDown = Ease.OutBack;
     [SerializeField] private float m_DurationOfScaleDown = 0.3f;
     [SerializeField] private Vector3 m_OffsetOfBubble = new Vector3(-2 , -2 , 0);

    //During animation vars
    private Action m_OnFinishDialogue;
    private string[] m_TextsToPlay;
    private int m_CurrentTextIndex;
    private bool m_IsAnimatingText;
    private Vector3 m_OriginalOutOfScreenPosition;

    [Header("Max values for bubble")] 
    [SerializeField] private float m_MaxX;
    [SerializeField] private float m_MinX;
    [SerializeField] private float m_MaxY;

    private void Start()
    {
        m_FullSizeScale = m_DialogueBox.lossyScale;
        m_OriginalOutOfScreenPosition = m_DialogueBox.position;
    }  
    
    [Button()]
    private void TestDialogue()
    {
        m_DialogueBox.localScale = Vector3.zero;
        Debug.Log(m_FullSizeScale);
        PlayDialogueText(m_SampleText , null , Vector3.zero);
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
            m_IsAnimatingText = false;
            m_DialogueText.maxVisibleCharacters = m_DialogueText.text.Length;
            return;
        }

        m_CurrentTextIndex++;
        Debug.Log(m_CurrentTextIndex);
        Debug.Log(m_TextsToPlay.Length);
        if (m_CurrentTextIndex >= m_TextsToPlay.Length)
        {
            m_DialogueBox.DOScale(Vector3.zero, m_DurationOfScaleDown).SetEase(m_EaseOfScaleUp).OnComplete(()=>
            {
                m_DialogueBox.position = m_OriginalOutOfScreenPosition;
                m_IsDialogueOpen.Value = false;
            });
            m_OnFinishDialogue?.Invoke();
            Debug.Log("STOP DIALOGUE");
            return;
        }
        StartCoroutine(TypeMachineText(m_TextsToPlay[m_CurrentTextIndex]));
    }

    public void PlayDialogueText(string[] text , Action onFinishDialogue , Vector3 positionOfObject)
    {
        Debug.Log("Play dialogue");
        m_DialogueBox.DOScale(m_FullSizeScale, m_DurationOfScaleUp).SetEase(m_EaseOfScaleUp);
        m_DialogueBox.transform.position = positionOfObject + m_OffsetOfBubble;
        ConstrainPositionOfBubbleOnScreen();
        
        m_OnFinishDialogue = onFinishDialogue;
        m_CurrentTextIndex = 0;
        m_TextsToPlay = text;
        m_IsDialogueOpen.Value = true;
        m_DialogueText.text = string.Empty;
        StartCoroutine(TypeMachineText(text[m_CurrentTextIndex]));
    }
    
    private void ConstrainPositionOfBubbleOnScreen()
    {
        if (m_DialogueBox.transform.position.y > m_MaxY)
        {
            m_DialogueBox.transform.position = new Vector3(m_DialogueBox.transform.position.x, m_MaxY,
                m_DialogueBox.transform.position.z);
        }
        if (m_DialogueBox.transform.position.x > m_MaxX)
        {
            m_DialogueBox.transform.position = new Vector3(m_MaxX, m_DialogueBox.transform.position.y,
                m_DialogueBox.transform.position.z);
        }
        if (m_DialogueBox.transform.position.x < m_MinX)
        {
            m_DialogueBox.transform.position = new Vector3(m_MinX, m_DialogueBox.transform.position.y,
                m_DialogueBox.transform.position.z);
        }
    }

    private IEnumerator TypeMachineText(string text)
    {
        m_DialogueText.text = text;
        m_IsAnimatingText = true;
        int numberOfLetters = text.Length;
        m_DialogueText.maxVisibleCharacters = 0;
        for (int i = 0; i < numberOfLetters; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.03f , 0.04f));
            m_DialogueText.maxVisibleCharacters = i;
        }

        m_IsAnimatingText = false;
        yield return null;
    }
}
