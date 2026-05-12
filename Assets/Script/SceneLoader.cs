    using System;
    using Unity.VectorGraphics;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class SceneLoader : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            scoreText.text = $"Score: {Poop.Score}";
        }
        
        
        public void GameStart()
        {
            SceneManager.LoadScene("TitleScene");
        }

        public void OnPressStartButton()
        {
            SceneManager.LoadScene("GameScene");
            Poop.Score = 0;
        }

        public void OnPressQuitButton()
        {
            Application.Quit();
        }
        
    }
