using UnityEngine;

public class WorldChangeController : SingletonMono<WorldChangeController>
{
    public bool IsNormalWorld;

    [SerializeField] private SpriteRenderer m_Background;
    [SerializeField] private SpriteRenderer m_Door;
    [SerializeField] private BoxCollider2D m_ClockCollider;
    [SerializeField] private Color m_FalseWordlColor;

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
        m_ClockCollider.enabled = realWorld;
        m_Background.color = realWorld ? Color.white : m_FalseWordlColor;
    }
}
