using UnityEngine;


public class ResetWall : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wifi") || collision.CompareTag("heart"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
