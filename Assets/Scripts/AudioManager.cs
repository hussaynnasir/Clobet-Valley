using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private  AudioSource audioSource;

    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCollectSound()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayFireLeave()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void PlayFireHit()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(audioClips[3]);
    }
}
