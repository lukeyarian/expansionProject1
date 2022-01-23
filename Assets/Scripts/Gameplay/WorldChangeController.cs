using UnityEngine;

public class WorldChangeController : SingletonMono<WorldChangeController>
{
    public bool IsNormalWorld;

    [SerializeField] private SpriteRenderer m_Background;
    [SerializeField] private SpriteRenderer m_Door;
    [SerializeField] private BoxCollider2D m_ClockCollider;
    [SerializeField] private Color m_FalseWordlColor;
    
    [SerializeField] private SpriteRenderer[] m_StuffThatExistInRealWorldOnly;
    [SerializeField] private GameObject m_ClockGameObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            IsNormalWorld = !IsNormalWorld;
            SetWorldFor(IsNormalWorld);
        }
    }

    private void SetWorldFor(bool realWorld)
    {
        if (m_ClockGameObject != null)
        {
            m_ClockCollider.enabled = realWorld;
        }
        m_Background.color = realWorld ? Color.white : m_FalseWordlColor;
        SetRenderersDependingOnWorld(realWorld);
    }

    private void SetRenderersDependingOnWorld(bool realWorld)
    {
        for (int i = 0; i < m_StuffThatExistInRealWorldOnly.Length; i++)
        {
            if (m_StuffThatExistInRealWorldOnly[i] == null) continue;
            m_StuffThatExistInRealWorldOnly[i].enabled = realWorld;
        }
    }
}
