using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catController : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] float sideMov = 5f;
    [SerializeField] [Range(1f, 5f)] float jForce = 5f;
    bool leftReq, rightReq, jumpReq, canJump = false, faceL = true;


    void Awake()
    {
        if(GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            leftReq = true;
            if(!faceL)
            {
                faceL = true;
                transform.Rotate(new Vector3(0, 180f, 0));
            }   
        }
        else
        {
            leftReq = false;
        }
        if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rightReq = true;
            if(faceL)
            {
                faceL = false;
                transform.Rotate(new Vector3(0, 180f, 0));
            }
        }
        else
        {
            rightReq = false;
        }
        if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            jumpReq = true;
        }
        else
        {
            jumpReq = false;
        }
    }

    void FixedUpdate()
    {
        if(leftReq)
        {
            transform.position += new Vector3(-sideMov * Time.deltaTime, 0f, 0f);
        }
        if(rightReq)
        {
            transform.position += new Vector3(sideMov * Time.deltaTime, 0f, 0f);
        }
        if(jumpReq && canJump)
        {
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.collider.tag == "Ground")
        {
            canJump = true;
        }
    }

    void Jump()
    {
        canJump = false;
        GetComponent<Rigidbody2D>().velocity += Vector2.up * jForce;
    }
}
