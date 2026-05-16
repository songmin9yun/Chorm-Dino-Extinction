    using System;
    using Unity.VectorGraphics;
    using Unity.VisualScripting;
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;
    using UnityEngine.SocialPlatforms.Impl;

    public class SceneLoader : MonoBehaviour
    { // 오류: 텍스트메세지 매니저 따로만들어서 하기, 버튼 초기화 되서 안눌림

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
