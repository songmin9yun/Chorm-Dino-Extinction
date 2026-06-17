using UnityEditor.Searcher;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public float _speed = 0;
    public float followspeed = 0;
    public Transform Player;
    
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        _speed = 0;
        followspeed = 0;
        Player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    

    
    private void FixedUpdate()
    {
        if (transform.position.x > Player.position.x)
        {
            rb.linearVelocity = new Vector2(-followspeed, -_speed + rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(followspeed, -_speed + rb.linearVelocity.y);
        }
        _speed += Time.fixedDeltaTime / 200;
        followspeed += Time.fixedDeltaTime / 40;
    }
}
