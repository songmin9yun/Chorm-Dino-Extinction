using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    [SerializeField] private Image image;
    
    public RectTransform rectTransform;
    public UIManager manager;
    public Sound sound;

    [SerializeField] private Color currentColor;
    [SerializeField] private Color changeColor;

    [SerializeField] private int code = 0;

    public static bool isclicked;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Start()
    {
        isclicked = false;
        if (code == 2)
        {
            sound.dieAudioPlay();
        }
    }
    
    public void OnPressScorollbar()
    {
        if (isclicked && PlayerMove.hp == 0)
        {
            image.color = Color.Lerp(changeColor, currentColor, 1);
            isclicked = false;
            
            if (code == 1)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(transform.position, new Vector2(-20, 0), 1);
                manager.isClickImage();
            }
        }
        else if (isclicked && Timer.score > 0 && code == 1)
        {
            sound.dieAudioPlay();
        }
        else
        {
            image.color = Color.Lerp(currentColor, changeColor, 1);
            isclicked = true;
            
            if (code == 1)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(transform.position, new Vector2(20, 0), 1);
                manager.noClickImage();
            }
        }
    }
}
