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

    void Update()
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
