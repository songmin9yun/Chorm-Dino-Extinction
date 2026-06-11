using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] private Imagechange imagechange;
    //[SerializeField] private ErrorImage errorImage;
    [SerializeField] private UIManager UIManager;
    public static int hp;

    // [Header("Ground Check")]
    // [SerializeField] private float groundDistance = 0.2f;
    // [SerializeField] private LayerMask groundLayer;
    
    [Header("Move")]
    [SerializeField] private float Speed = 15f;
    public bool isGrounded;
    public bool isRunning;
    public float jumpForce = 7f;
    
    private SpriteRenderer sr;
    public Animator animator;
    public Timer timer;

    public float x;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        hp = 3;
    }
    void Start()
    {
        Speed = 10f;
        
        imagechange.change();
    }

    void Update() 
    {
        
        x = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            isRunning = true;
            if (Speed < 20f && isGrounded && Mathf.Abs(rb.linearVelocity.x) > 0.1f)
            {
                Speed += 0.05f;
            }
            else if (Speed > 10f && isGrounded)
            {
                Speed -= 0.05f;
            }
        }
        else
        {
            isRunning = false;
            if (Speed > 10f && isGrounded)
            {
                Speed -= 0.05f;
            }
        }
        

        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                jump();
                animator.SetTrigger("stop");
            }
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * Speed, rb.linearVelocity.y);
        
        if (rb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = false;
        }

        if (Mathf.Abs(rb.linearVelocity.x) > 0.1f && isRunning && isGrounded) 
        {
            animator.SetTrigger("down");
        }
        else if (Mathf.Abs(rb.linearVelocity.x) > 0.1f && !isRunning && isGrounded) 
        {
            animator.SetTrigger("move");
        }
        else
        {
            animator.SetTrigger("stop");
        }
    }

    private void jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("poop"))
        {
            if (0 < hp && hp < imagechange.srLen)
            {
                hp--;
                imagechange.change();
                //errorImage.change();
                if (hp < 1)
                {
                    timer.ResetTimer();
                    SceneManager.LoadScene("TitleScene");
                }
                collision.gameObject.SetActive(false);
            }
            
        }

        if (collision.CompareTag("heart"))
        {
            if (0 < hp && hp < imagechange.srLen - 1)
            {
                hp++;
                imagechange.change();
                //errorImage.change();
                collision.gameObject.SetActive(false);
            }
            
        }
    }

    //void GroundedCheck()
    //{
        // RaycastHit2D hit =
        //     Physics2D.Raycast(
        //         transform.position,
        //         Vector2.down,
        //         groundDistance,
        //         groundLayer);
        //
        // isGrounded = hit.collider != null;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true; //laycast2D로 바닥에 빛을 쏴서 체크
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = false;
        }
    }
}

