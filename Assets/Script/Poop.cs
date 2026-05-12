using UnityEngine;

public class Poop : MonoBehaviour
{
    public float _speed = 0f;
    public float followspeed = 0;
    public Transform Player;

    public static int Score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 0;
        followspeed = 0;
        Player = GameObject.FindWithTag("Player").transform;
    }

    
    private void FixedUpdate()
    {
        Vector3 dir;
        if (transform.position.x > Player.position.x)
        {
            dir = new Vector3(-followspeed, -_speed, 0);
        }
        else
        {
            dir = new Vector3(followspeed, -_speed, 0);
        }
        
        transform.position += dir * Time.fixedDeltaTime;
        _speed += Time.fixedDeltaTime / 4;
        followspeed += Time.fixedDeltaTime / 40;
        
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        Score++;
    }
}
