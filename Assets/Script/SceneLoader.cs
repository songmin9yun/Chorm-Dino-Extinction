    using System;
    using Unity.VectorGraphics;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using TMPro;

    public class SceneLoader : MonoBehaviour
    {
        public void GameStart()
        {
            SceneManager.LoadScene("TitleScene");
        }

        public void OnPressStartButton()
        {
            Poop.Score = 0;
            SceneManager.LoadScene("GameScene");
        }

        public void OnPressQuitButton()
        {
            Application.Quit();
        }
        
    }
