using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickedUpItemView : MonoBehaviour
{
    [SerializeField] private Image m_ImageOfBackground;
    [SerializeField] private Button m_WholeButton;

    public void SetView(Sprite spriteToSet, UnityAction buttonAction)
    {
        m_ImageOfBackground.sprite = spriteToSet;
        m_WholeButton.SetClickAction(buttonAction + (() => MouseFollower.SetImage(m_ImageOfBackground.sprite)));
    }
}
