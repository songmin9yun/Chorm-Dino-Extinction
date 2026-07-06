using UnityEditor.Searcher;
using UnityEngine;
using System.Collections;

public class Poop : MonoBehaviour
{
    public float _speed = 0;
    public float followspeed = 0;
    public Transform Player;
    
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private ParticleOff particleOff;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        particleOff = GetComponent<ParticleOff>();
        Player = GameObject.FindWithTag("Player").transform;    
    }
    
    void Start()
    {
        _speed = 0;
        followspeed = 0;
    }

    void OnEnable()
    {
        particleOff.particleOn();
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
        //followspeed += Time.fixedDeltaTime / 40;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("resetWall"))
        {
            StartCoroutine(DisableObject());
        }
    }
    
    IEnumerator DisableObject()
    {
        particleOff.particleOff();

        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
