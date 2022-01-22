using UnityEngine;

public class InteractionController : SingletonMono<InteractionController>
{
    private bool m_AlreadyInteracting = false;
    [SerializeField] private BoolVariable m_OnDialogue;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
            
            if(hit.collider != null)
            {
                var interactableClicked = hit.collider.GetComponent<IINteractable>();
                interactableClicked?.Interact();
                
                var pickablePickedUp = hit.collider.GetComponent<PickUpAble>();
                if (pickablePickedUp != null && interactableClicked == null && !m_OnDialogue.Value && pickablePickedUp.CanBePickedUp())
                {
                    GameEventSystem.Current.AddItemToPlayerInventory(pickablePickedUp.ItemData);
                }
            }
        }
    }
}
