using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [SerializeField] private float Speed;
    [SerializeField] private float[] randomX;
    [SerializeField] private float[] randomY;
    [SerializeField] private float[] randomSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //Speed = Random.Range(-4f, -1f);
        
        Speed = Random.Range(randomSpeed[0], randomSpeed[1]);
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);
    }

    private void OnBecameInvisible()
    {
        // Speed = Random.Range(-2.5f, -1f);
        // rb.MovePosition(new Vector2(9.5f, Random.Range(-4f, -7.5f)));
        
        Speed = Random.Range(randomSpeed[0], randomSpeed[1]);
        rb.MovePosition(new Vector2(Random.Range(randomX[0], randomX[1]), Random.Range(randomY[0], randomY[1])));
    }
}
