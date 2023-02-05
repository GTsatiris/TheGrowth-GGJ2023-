using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{
        public GameObject IntroPanel;
        public GameObject CreditsPanel;
        public void Play()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Credits()
        {
            CreditsPanel.SetActive(true);
            IntroPanel.SetActive(false);
        }

        public void Back()
        {
        CreditsPanel.SetActive(false);
        IntroPanel.SetActive(true);
    }
        public void QuitGame() {
            Application.Quit();
        }

}
