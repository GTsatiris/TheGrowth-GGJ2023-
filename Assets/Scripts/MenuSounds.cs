using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;

    private void Awake() {
        audioSource = GameObject.Find("Fx").GetComponent<AudioSource>();
    }
    public void Hover() {
        audioSource.PlayOneShot(sounds[0]);
    }
    public void Click() {
        audioSource.PlayOneShot(sounds[1]);
    }
}
