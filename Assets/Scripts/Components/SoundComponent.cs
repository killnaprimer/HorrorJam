using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    public bool stopOnInteract;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Interact(GameObject instigator)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            if (stopOnInteract) audioSource.Stop();
        }
    }
}
