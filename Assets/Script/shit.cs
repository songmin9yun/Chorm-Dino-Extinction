using UnityEngine;

public class shit : MonoBehaviour
{
    public static float _speed = 0f;
    public static float followspeed = 0;
    public Transform Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 0;
        followspeed = 0;
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        _speed += Time.fixedDeltaTime * 4;
        followspeed += Time.fixedDeltaTime * 2;
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
