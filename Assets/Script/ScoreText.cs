using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Sound sound;

    private int count1;
    private bool isBlink;

    void Start()
    {
        count1 = 1;
    }

    void Update()
    {
        if (Timer.score >= count1 * 100 && !isBlink)
        {
            count1++;
            sound.pointAudioPlay();
            StartCoroutine(BlinkScore());
        }

        if (!isBlink)
        {
            scoreText.text = $"HI {Timer.highScore:00000} {Mathf.CeilToInt(Timer.score):00000}";
        }
    }

    IEnumerator BlinkScore()
    {
        isBlink = true;
        
        for (int i = 0; i < 4; i++)
        {
            scoreText.text = "";
            yield return new WaitForSeconds(0.25f);
            
            scoreText.text = $"HI {Timer.highScore:00000} {(count1-1) * 100 :00000}";
            yield return new WaitForSeconds(0.25f);
        }

        isBlink = false;
    }
}
