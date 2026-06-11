using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fly : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float Speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Speed = Random.Range(-8f, -7f);
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);
    }

    private void OnBecameInvisible()
    {
        Speed = Random.Range(-8f, -7f);
        rb.MovePosition(new Vector2(Random.Range(100f, 150f), Random.Range(-3f, -7.5f)));
    }
}