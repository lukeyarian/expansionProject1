using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private bool m_AlreadyInteracting = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hit");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            // If it hits something...
            if (hit.collider != null)
            {
                /*
                // Calculate the distance from the surface and the "error" relative
                // to the floating height.
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                float heightError = floatHeight - distance;

                // The force is proportional to the height error, but we remove a part of it
                // according to the object's speed.
                float force = liftForce * heightError - rb2D.velocity.y * damping;

                // Apply the force to the rigidbody.
                rb2D.AddForce(Vector3.up * force);
                */
            }
        }
    }
}
