    using System;
    using Unity.VectorGraphics;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void GameStart()
        {
            SceneManager.LoadScene("TitleScene");
        }

        public void OnPressStartButton()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnPressQuitButton()
        {
            Application.Quit();
        }

        

        // Update is called once per frame
        void Update()
        {
            
        }
    }
