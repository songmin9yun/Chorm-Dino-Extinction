using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private TextMeshProUGUI hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpText.text = $"HP: {hp}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {   
        float a = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(a, b, 0);
        
        transform.position += dir * 12 * Time.fixedDeltaTime;
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shit")
        {
            hp--;
            hpText.text = $"HP: {hp}";
            if (hp < 1)
            {
                SceneManager.LoadScene("TitleScene");
            }
            Destroy(collision.gameObject);
        }
    }
}
