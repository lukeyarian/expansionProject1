using UnityEngine;

public class InteractionController : SingletonMono<InteractionController>
{
    private bool m_AlreadyInteracting = false;
    
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
            }

        }
    }
}
