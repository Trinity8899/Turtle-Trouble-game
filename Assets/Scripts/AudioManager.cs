using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Audio sources for music and sound effects.

    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    // Audio clips for background, game over, and pickup sounds.
    
    [Header("--------Audio Clip--------")]
    public AudioClip background;
    public AudioClip gameOver;
    public AudioClip pickUp;

    // Play background music on start.

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    
    // Play a one-shot sound effect.
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);


    }

    public void StopMusic()
    { 
        musicSource.Stop();
    
    }



    

}
