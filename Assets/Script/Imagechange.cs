using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Imagechange : MonoBehaviour
{
    public Sprite[] sprites;
    private Image img;
    public int srLen;
    

    void Awake()
    { 
        img = GetComponent<Image>();
    }

    void Start()
    {
        srLen = sprites.Length;
    }
    public void change()
    {
        if (0 < PlayerMove.hp && PlayerMove.hp < srLen)
        {
            img.sprite = sprites[PlayerMove.hp];
        }
    }
}
