using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{

    public GameObject IntroPanel;
    public GameObject CreditsPanel;
    public Animator transition;
    public float transitionTime = 5f;

    public GameObject loading;
    public void Play()
    {
        LoadNextLevel();
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
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        if (SceneManager.GetActiveScene().buildIndex + 1 == 1)
        {
            loading.SetActive(true);
        }
        else
        {
            loading.SetActive(false);
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }

}
