using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public static int hp;
    [SerializeField] private float Speed = 12f;
    public bool isGrounded;
    public float jumpForce = 5f;

    public float x;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 3;
         // 입력은 Update에서 받기 이동은 velocity로 바꾸기
        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                jump();
            }
        }
    }
    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * Speed, rb.linearVelocity.y);

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
            if (hp < 1)
            {
                SceneManager.LoadScene("TitleScene");
            }
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("heart"))
        {
            hp++;
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

