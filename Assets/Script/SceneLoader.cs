    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        void Awake()
        {
            if (Timer.highScore == 0)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        public void OnPressStartButton()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnPressQuitButton()
        {
            Application.Quit();
        }
        
    }
