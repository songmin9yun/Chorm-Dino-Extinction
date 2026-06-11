using UnityEngine;

public class Timer : MonoBehaviour
{
    public static int score;
    public static float highScore = 0;

    private float timer;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.1)
        {
            score++;
            timer = 0;
        }
    }

    public void ResetTimer()
    {
        if (highScore < score)
        {
            highScore = score;
        }
    }
}
