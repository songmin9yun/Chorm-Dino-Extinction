using UnityEngine;

public class Poop : MonoBehaviour
{
    public float _speed = 0f;
    public float followspeed = 0;
    public Transform Player;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer trail;
    
    public static int Score = 0;
    
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
        _speed += Time.fixedDeltaTime / 400;
        followspeed += Time.fixedDeltaTime / 80;
        
    }

    private void OnBecameInvisible()
    {
        Score++;
        gameObject.SetActive(false);
        
    }

    public void StartTrail()
    {
        trail.emitting = true;
    }

    public void StopTrail()
    {
        trail.emitting = false;
    }
}
