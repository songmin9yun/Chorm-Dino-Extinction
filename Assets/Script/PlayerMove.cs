using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Imagechange imagechange;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private Sound sound;
    
    public static int hp;
    public bool I_frames;

    public Material flashMaterial;
    public Material defaultMaterial;
    
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
        I_frames = false;
        
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
                Speed += 30f * Time.deltaTime;
            }
            else if (Speed > 10f && isGrounded)
            {
                Speed -= 30f * Time.deltaTime;
            }
        }
        else
        {
            isRunning = false;
            if (Speed > 10f && isGrounded)
            {
                Speed -= 30f * Time.deltaTime;
            }
        }
        

        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                jump();
                sound.jumpAudioPlay();
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
        if (collision.CompareTag("wifi"))
        {
            if (0 < hp && hp < imagechange.srLen)
            {
                if (I_frames == false)
                {
                    Flash();
                
                    hp--;
                    imagechange.change();
                    sound.dieAudioPlay();
                    if (hp < 1)
                    {
                        timer.ResetTimer();
                        SceneManager.LoadScene("TitleScene");
                    }
                }
                collision.gameObject.SetActive(false);
            }
            
        }

        if (collision.CompareTag("heart"))
        {
            if (0 < hp && hp < imagechange.srLen - 1)
            {
                Flash();
                
                hp++;
                imagechange.change();
                //errorImage.change();
                collision.gameObject.SetActive(false);
            }
            
        }
    }

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


    void Flash()
    {
        I_frames = true;
        GetComponent<SpriteRenderer>().material = flashMaterial;
        Invoke("AfterFlash", 0.5f);
    }

    void AfterFlash()
    {
        I_frames = false;
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
}

