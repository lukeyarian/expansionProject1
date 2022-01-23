using UnityEngine;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    [SerializeField] private Button m_ExitButton;

    private void Awake()
    {
        m_ExitButton.SetClickAction(Application.Quit);
    }
}
