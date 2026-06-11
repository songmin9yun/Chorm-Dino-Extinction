using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float Speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Speed = Random.Range(-4f, -1f);
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);
    }

    private void OnBecameInvisible()
    {
        Speed = Random.Range(-2.5f, -1f);
        rb.MovePosition(new Vector2(9.5f, Random.Range(-4f, -7.5f)));
    }
}
