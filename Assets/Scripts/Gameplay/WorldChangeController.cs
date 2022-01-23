using UnityEngine;

public class WorldChangeController : SingletonMono<WorldChangeController>
{
    public bool IsNormalWorld = true;

    [SerializeField] private SpriteRenderer m_Background;
    [SerializeField] private BoxCollider2D m_ClockCollider;
    [SerializeField] private Color m_FalseWordlColor;
    
    [SerializeField] private SpriteRenderer[] m_StuffThatExistInRealWorldOnly;
    [SerializeField] private SpriteRenderer[] m_StuffThatExistsInFakeWorldOnly;
    [SerializeField] private GameObject m_ClockGameObject;
    
    [Header("Background")]
    [SerializeField] private Sprite m_RealWorldBg;
    [SerializeField] private Sprite m_FakeWorldBg;
    
    [Header("Robert")]
    [SerializeField] private SpriteRenderer m_Plant;
    [SerializeField] private Sprite m_SpritePlantReal;
    [SerializeField] private Sprite m_SpritePlantFake;
    
    [Header("Window")]
    [SerializeField] private SpriteRenderer m_Window;
    [SerializeField] private Sprite m_FakeWindow;
    [SerializeField] private Sprite m_RealWindow;
    
    [Header("LeftDoor")]
    [SerializeField] private SpriteRenderer m_DoorOuter;
    [SerializeField] private Sprite m_RealWorldDoorOuter;
    [SerializeField] private Sprite m_FakeWorldDoorOuter;
    
    [Header("LeftDoorInner")]
    [SerializeField] private SpriteRenderer m_DoorInner;
    [SerializeField] private Sprite m_RealWorldInnerOpen;
    [SerializeField] private Sprite m_RealWorldInnerClosed;
    [SerializeField] private Sprite m_FakeWorldInnerOpen;
    [SerializeField] private Sprite m_FakeWorldInnerClosed;

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
        //m_Background.color = realWorld ? Color.white : m_FalseWordlColor;
        SetRenderersDependingOnWorld(realWorld);
    }

    private void SetRenderersDependingOnWorld(bool realWorld)
    {
        for (int i = 0; i < m_StuffThatExistInRealWorldOnly.Length; i++)
        {
            if (m_StuffThatExistInRealWorldOnly[i] == null) continue;
            m_StuffThatExistInRealWorldOnly[i].enabled = realWorld;
        }
        for (int i = 0; i < m_StuffThatExistsInFakeWorldOnly.Length; i++)
        {
            if (m_StuffThatExistsInFakeWorldOnly[i] == null) continue;
            m_StuffThatExistsInFakeWorldOnly[i].enabled = !realWorld;
        }

        m_Background.sprite = realWorld ? m_RealWorldBg : m_FakeWorldBg;
        m_Plant.sprite = realWorld ? m_SpritePlantReal : m_SpritePlantFake;
        m_Window.sprite = realWorld ? m_RealWindow : m_FakeWindow;
        m_DoorOuter.sprite = realWorld ? m_RealWorldDoorOuter : m_FakeWorldDoorOuter;
        SetDoorState(realWorld);
    }

    public void SetDoorState(bool isRealWorld)
    {
        bool isDoorOpen = EventConditionBooleans.HasOpenedDoor;
        if (isRealWorld)
        {
            m_DoorInner.sprite = isDoorOpen ? m_RealWorldInnerOpen : m_RealWorldInnerClosed;
        }
        else
        {
            m_DoorInner.sprite = isDoorOpen ? m_FakeWorldInnerOpen : m_FakeWorldInnerClosed;
        }
    }
}
