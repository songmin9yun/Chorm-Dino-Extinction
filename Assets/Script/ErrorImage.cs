using UnityEngine;

public class ErrorImage : MonoBehaviour
{
    public SpriteRenderer sr;
    [SerializeField] private int num;
    [SerializeField] private Sprite[] errorImage;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void change()
    {
        if (PlayerMove.hp <= num)
        {
            sr.sprite = errorImage[0];
        }
        else
        {
            sr.sprite = errorImage[1];
        }
    }
}
