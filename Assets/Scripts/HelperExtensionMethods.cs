using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class HelperExtensionMethods
{
    public static void SetClickAction(this Button button , UnityAction action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action);
    }
    
    public static void AddClickAction(this Button button , UnityAction action)
    {
        button.onClick.AddListener(action);
    }
}
