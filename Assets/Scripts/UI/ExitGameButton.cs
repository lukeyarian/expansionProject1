using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().SetClickAction(()=>
        {
            Debug.Log("CLOSE GAME"); 
            Application.Quit();
        });
    }
}
