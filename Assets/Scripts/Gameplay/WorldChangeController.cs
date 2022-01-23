﻿using UnityEngine;

public class WorldChangeController : SingletonMono<WorldChangeController>
{
    public bool IsNormalWorld;

    [SerializeField] private SpriteRenderer m_Background;
    [SerializeField] private BoxCollider2D m_ClockCollider;
    [SerializeField] private Color m_FalseWordlColor;
    
    [SerializeField] private SpriteRenderer[] m_StuffThatExistInRealWorldOnly;
    [SerializeField] private GameObject m_ClockGameObject;
    
    [Header("Background")]
    [SerializeField] private Sprite m_RealWorldBg;
    [SerializeField] private Sprite m_FakeWorldBg;
    
    [Header("Robert")]
    [SerializeField] private SpriteRenderer m_Plant;
    [SerializeField] private Sprite m_SpritePlantReal;
    [SerializeField] private Sprite m_SpritePlantFake;
    
    [Header("LeftDoor")]
    [SerializeField] private SpriteRenderer m_Door;
    [SerializeField] private Sprite m_RealWorldClosed;
    [SerializeField] private Sprite m_REalWorldOpen;
    [SerializeField] private Sprite m_FakeWorldClosed;
    [SerializeField] private Sprite m_FakeWorldOpen;

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

        m_Background.sprite = realWorld ? m_RealWorldBg : m_FakeWorldBg;
        m_Plant.sprite = realWorld ? m_SpritePlantReal : m_SpritePlantFake;
    }
}
