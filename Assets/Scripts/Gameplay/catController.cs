using UnityEngine;

public class catController : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    [SerializeField] [Range(1f, 10f)] float sideMov = 5f;
    [SerializeField] [Range(1f, 5f)] float jForce = 5f;
    bool leftReq, rightReq, jumpReq, canJump = false, faceL = true;
    
    [SerializeField] Animator m_CatAnimator;
    [SerializeField] Rigidbody2D m_CatRb;
    private static readonly int IsWalking = Animator.StringToHash(IS_WALKING);
    [SerializeField] private Sprite m_FrontSprite;
    [SerializeField] private Sprite m_BackSprite;
    [SerializeField] private SpriteRenderer m_CatSpriteRenderer;
    [SerializeField] private BoolVariable m_CanMove;


    void Awake()
    {
        if(GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        m_CatAnimator.SetBool(IsWalking, false);
    }

    void Update()
    {
        if (!m_CanMove.Value)
        {
            rightReq = false;
            leftReq = false;
            return;
        }
        bool didPressKey = false;
        if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            m_CatAnimator.enabled = true;
            m_CatAnimator.SetBool(IsWalking, true);
            didPressKey = true;
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
            m_CatAnimator.enabled = true;
            m_CatAnimator.SetBool(IsWalking, true);
            didPressKey = true;
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
        if(Input.GetKey(KeyCode.Space))
        {
            m_CatAnimator.enabled = true;
            m_CatAnimator.SetBool(IsWalking, true);
            didPressKey = true;
            jumpReq = true;
        }
        else
        {
            jumpReq = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !didPressKey)
        {
            Debug.Log("SET BACK SPRITE");
            m_CatAnimator.enabled = false;
            m_CatSpriteRenderer.sprite = m_BackSprite;
        }
        
        if (Input.GetKeyDown(KeyCode.S) && !didPressKey)
        {
            m_CatAnimator.enabled = false;
            m_CatSpriteRenderer.sprite = m_FrontSprite;
        }

        if (!didPressKey)
        {
            m_CatAnimator.SetBool(IsWalking, false);
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
