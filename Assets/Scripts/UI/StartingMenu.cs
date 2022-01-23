using UnityEngine;
using UnityEngine.UI;

public class StartingMenu : MonoBehaviour
{
    public Button WholeScreenButton;
    public Canvas WholeCanvas;
    
    void Start()
    {
        WholeScreenButton.SetClickAction(()=>WholeCanvas.enabled = false);
    }
}
