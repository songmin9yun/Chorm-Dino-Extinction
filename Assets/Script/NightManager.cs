using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NightManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image img;

    [SerializeField] private Color currentColor;
    [SerializeField] private Color changeColor;

    [SerializeField] private int nightCount = 1;
    [SerializeField] private int nightRange = 350;

    [SerializeField] private float changeTime = 1;

    private bool isnight = false;

    [SerializeField] private int code;  // 0:sprite, 1:text, 2:image
    
    void Awake()
    {
        if (code == 0) sprite = GetComponent<SpriteRenderer>();
        else if (code == 1) text = GetComponent<TextMeshProUGUI>();
        else if (code == 2) img = GetComponent<Image>();
    }

    void Start()
    {
        if (code == 0) sprite.color = currentColor;
        else if (code == 1) text.color = currentColor;
        else if (code == 2) img.color = currentColor;
    }
    
    void Update()
    {
        if (Timer.score >= nightCount * nightRange)
        {
            isnight = true;
        }
        if (Timer.score >= nightCount * nightRange + 200)
        {
            isnight = false;
            nightCount++;
        }
        
        if (isnight)
        {
            if (code == 0)
            {
                sprite.color = Color.Lerp(
                    sprite.color,
                    changeColor,
                    changeTime * Time.deltaTime);
            }

            else if (code == 1)
            {
                text.color = Color.Lerp(
                    text.color,
                    changeColor,
                    changeTime * Time.deltaTime);
            }
            else if (code == 2)
            {
                img.color = Color.Lerp(
                    img.color,
                    changeColor,
                    changeTime * Time.deltaTime);
            }
        }
        else
        {
            if (code == 0)
            {
                sprite.color = Color.Lerp(
                    sprite.color,
                    currentColor,
                    changeTime * Time.deltaTime);
            }
            else if (code == 1)
            {
                text.color = Color.Lerp(
                    text.color,
                    currentColor,
                    changeTime * Time.deltaTime);
            }
            else if (code == 2)
            {
                img.color = Color.Lerp(
                    img.color,
                    currentColor,
                    changeTime * Time.deltaTime);
            }
        }
    }
}
