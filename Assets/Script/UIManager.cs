using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshPro hpText;
 
    
    void Start()
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {Poop.Score}";
        }

        if (hpText != null)
        {
            hpText.text = $"HP:{PlayerMove.hp}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {Poop.Score}";
        }

        if (hpText != null)
        {
            hpText.text = $"HP: {PlayerMove.hp}";
        }
    }
    
}
