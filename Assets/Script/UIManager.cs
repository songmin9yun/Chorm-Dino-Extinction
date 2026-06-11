using System;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = $"HI {Poop.Score}";
        }
        if (timeText != null)
        {
            timeText.text = $"HI {Timer.highScore} {Timer.score}";
        }
    }

    void Update()
    {
        timeText.text = $"HI {Timer.highScore:00000} {Mathf.CeilToInt(Timer.score):00000}";
    }
    // 바꿜때 마다 갱신되게 만들기
}
