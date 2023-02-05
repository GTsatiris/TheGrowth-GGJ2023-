using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] songs;
    private static SoundManager Instance;



    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start() {
        
    }

    private void OnEnable() {
        SceneManager.activeSceneChanged += CheckScene;
    }

    private void OnDisable() {
        SceneManager.activeSceneChanged -= CheckScene;
    }

    private void CheckScene(Scene currentScene, Scene nextScene) {
        if (nextScene.name == "GameScene") {

                audioSource.clip = songs[1];
                audioSource.Play();
            

        }else if(nextScene.name == "IntroScene" || nextScene.name == "CreditsScene") {
            
                audioSource.clip = songs[0];
                audioSource.Play();
            
        }
    }
}
