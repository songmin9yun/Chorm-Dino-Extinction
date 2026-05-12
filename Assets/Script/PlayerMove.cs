using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField] private int hp;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float Speed = 12f;

    private bool isGrounded;
    public float jumpForce = 5f;
    
    private float a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpText.text = $"HP: {hp}"; // 입력은 Update에서 받기 이동은 velocity로 바꾸기
        scoreText.text = $"Score: {Poop.Score}";
        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        a = Input.GetAxisRaw("Horizontal");
        scoreText.text = $"Score: {Poop.Score}";

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jump();
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(a * Speed, rb.linearVelocity.y);

        if (rb.linearVelocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (rb.linearVelocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (rb.linearVelocity.magnitude > 0)
        {
            GetComponent<Animator>().SetTrigger("move");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("stop");
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
            hp--;
            hpText.text = $"HP: {hp}";
            if (hp < 1)
            {
                SceneManager.LoadScene("TitleScene");
            }
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
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
