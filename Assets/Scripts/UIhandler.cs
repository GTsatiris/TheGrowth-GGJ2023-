using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{
        public void Play()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Credits()
        {
            SceneManager.LoadScene("CreditsScene");
        }

        public void Back()
        {
            SceneManager.LoadScene("IntroScene");
        }
        public void QuitGame() {
            Application.Quit();
        }

}
