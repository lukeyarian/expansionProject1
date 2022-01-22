using UnityEngine;

public class InteractionController : SingletonMono<InteractionController>
{
    private bool m_AlreadyInteracting = false;
    [SerializeField] private BoolVariable m_OnDialogue;
    [SerializeField] private BoolVariable m_OnTryingToUseItem ;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
            
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                IINteractable interactableClicked = null;
                if (InventoryController.Instance.LastItemClickedOnUI == null)
                {
                    Debug.Log("INteract simple");
                    interactableClicked = hit.collider.GetComponent<IINteractable>();
                    Debug.Log(interactableClicked);
                    interactableClicked?.Interact();
                }
                else
                {
                    Debug.Log("INteract with item");
                    interactableClicked = hit.collider.GetComponent<IINteractable>();
                    interactableClicked?.InteractWithItem(InventoryController.Instance.LastItemClickedOnUI.ItemType);
                }

                
                var pickablePickedUp = hit.collider.GetComponent<PickUpAble>();
                if (pickablePickedUp != null && interactableClicked == null && !m_OnDialogue.Value && pickablePickedUp.CanBePickedUp())
                {
                    GameEventSystem.Current.AddItemToPlayerInventory(pickablePickedUp.PickUpItem());
                }
            }
            InventoryController.Instance.LastItemClickedOnUI = null;
        }
    }
}
